    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Text;
    using System.Threading;
    
    namespace Echo
    {
        class Program
        {
            private static Process process;
            private static void Read(StreamReader reader)
            {
                new Thread(() =>
                {
                    while (!process.HasExited)
                    {
                        int current;
                        while ((current = reader.Read()) >= 0)
                            Console.Write((char)current);
                    }
                }).Start();
    
           }
    
            static void Main(string[] args)
            {
                ProcessStartInfo startInfo = new ProcessStartInfo(@"/usr/bin/ssh");
                startInfo.Arguments = "-ttt localhost";
                startInfo.CreateNoWindow = true;
                startInfo.ErrorDialog = false;
                startInfo.RedirectStandardError = true;
                startInfo.RedirectStandardInput = true;
                startInfo.RedirectStandardOutput = true;
                startInfo.UseShellExecute = false;
                startInfo.CreateNoWindow = true;
                process = new Process();
                process.StartInfo = startInfo;
                process.Start();
                Thread.Sleep(15000); //time to login
                Read(process.StandardOutput);
                Read(process.StandardError);
                process.StandardInput.WriteLine("echo echoing your input now");
                //Console.ReadLine();
                string theLine = "";
                while (!process.HasExited)
                    try {
                        ConsoleKeyInfo kinfo =  Console.ReadKey(true);
                       char thekey = kinfo.KeyChar;
                        theLine += thekey;
                        process.StandardInput.Write(thekey) ;
                        if (thekey.Equals('\n'))
                        {
                            Console.WriteLine(theLine);
    
                        }
    
                    }
                    catch { }
                Console.WriteLine(process.ExitCode.ToString());
            }
        }
    }
