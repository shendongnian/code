    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Diagnostics;
    
    namespace ConsoleApplication4
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                Pinger p = new Pinger();
                p.startNewThread();
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
    
        }
    
        public class Pinger
        {
            public void startNewThread()
            {
                Thread x = new Thread(new ThreadStart(Ping));
                x.IsBackground = true;
                x.Start();
            }
    
    
            private void Ping()
            {
                var p = new Process();
    
                p.StartInfo.FileName = "ping";
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.Arguments = "www.google.com";
                p.Start();
                while (p.StandardOutput.Peek() > -1)
                {
                    Console.WriteLine(p.StandardOutput.ReadLine());
                }
               
             
            }
        }
    }
