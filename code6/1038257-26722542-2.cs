    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Threading.Tasks;
    namespace TestSO26713374WaitForExit
    {
        class Program
        {
            static void Main(string[] args)
            {
                string foobat =
    @"START ping -t localhost
    START ping -t google.com
    ECHO Batch file is done!
    EXIT /B 123
    ";
                File.WriteAllText("foo.bat", foobat);
                Process p = new Process { StartInfo =
                    new ProcessStartInfo("foo.bat")
                    {
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    } };
                p.Start();
                var _ = ConsumeReader(p.StandardOutput);
                _ = ConsumeReader(p.StandardError);
                Console.WriteLine("Calling WaitForExit()...");
                p.WaitForExit();
                Console.WriteLine("Process has exited. Exit code: {0}", p.ExitCode);
                Console.WriteLine("WaitForExit returned.");
            }
            async static Task ConsumeReader(TextReader reader)
            {
                string text;
                while ((text = await reader.ReadLineAsync()) != null)
                {
                    Console.WriteLine(text);
                }
            }
        }
    }
