    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    
    class Program {
        static void Main(string[] args) {
            try {
                var path = Assembly.GetExecutingAssembly().Location;
                var dir = Path.GetDirectoryName(path);
                var file = Path.GetFileNameWithoutExtension(path);
                path = Path.Combine(dir, file + ".exe");
    
                var prc = Process.Start(path, Environment.CommandLine);
                if (args.Length > 0) prc.WaitForExit();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Environment.Exit(1);
            }
        }
    }
