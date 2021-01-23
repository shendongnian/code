    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var w = new Writer();
                var r = new Reader();
                while (!r.finish)
                {
                    w.enabled = true;
                    string k = Console.ReadKey(false).KeyChar.ToString();
                    w.enabled = false;
                    string line = k + Console.ReadLine();
                    r.Read(line);
                }
            }
        }
        class Writer
        {
            public bool enabled = true;
            public Writer()
            {
                var timer = new System.Timers.Timer(1000);
                timer.Elapsed += (a, b) =>
                {
                    if(enabled)
                        Console.WriteLine("Test");
                };
                timer.Start();
            }
        }
        class Reader
        {
            public bool finish = false;
            public void Read(string line)
            {
                if (line == "stop")
                {
                    finish = true;
                }
            }
        }
    }
