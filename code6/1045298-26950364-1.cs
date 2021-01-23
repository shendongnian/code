    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    using System.Threading;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
    
    
                //odd
                Thread _th1 = new Thread(new ThreadStart(delegate
                {
                    StreamWriter sw = File.AppendText("thread1.txt");
                    for (int i = 0; i <= 2000; i=i+2)
                    {
                        Console.WriteLine("th1:" + i.ToString());
                        sw.Write(i.ToString()+";");    
                    }
                    sw.Close();
                }));
    
                //even
                Thread _th2 = new Thread(new ThreadStart(delegate
                {
                    StreamWriter sw = File.AppendText("thread2.txt");
                    for (int i = 1; i <= 2000; i = i + 2)
                    {
                        Console.WriteLine("th2:" + i.ToString());
                        sw.Write(i.ToString()+";");
                    }
                    sw.Close();
                }));
    
                _th1.Start();
                _th2.Start();
    
                Console.Read();
            }
        }
    }
