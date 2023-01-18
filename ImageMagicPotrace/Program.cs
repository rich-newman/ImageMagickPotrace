using System.Diagnostics;
using System.Reflection;
#nullable disable 
namespace ImageMagicPotrace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = Path.GetDirectoryName(Assembly.GetAssembly(typeof(Program)).Location);
            string filesPath = Path.Combine(path, "Files");

            string fileName = "image";

            string imageMagick = "magick.exe";
            string arg = $"convert \"{Path.Combine(filesPath, fileName + ".png")}\" \"{Path.Combine(filesPath, fileName + ".pnm")}\"";
            RunProcess(imageMagick, arg);

            string potrace = Path.Combine(path, @"potrace\potrace.exe");
            string arg2 = $"\"{Path.Combine(filesPath, fileName + ".pnm")}\" -b svg";
            RunProcess(potrace, arg2);

            Console.WriteLine("Done");
        }

        private static void RunProcess(string executable, string arg)
        {
            Console.WriteLine(executable);
            Console.WriteLine(arg);
            ProcessStartInfo start = new ProcessStartInfo(executable)
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                Arguments = arg,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            Process process = Process.Start(start);
            process.WaitForExit();
        }
    }
}