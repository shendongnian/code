    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            const int nNumbers = 20000000;
    
            static string[] values = new string[nNumbers];
            static string[] file = new string[nNumbers];
    
            static Random rand = new Random();
    
            // Create some sample data.
            static void Init()
            {
                string sgn = "";
                for (int i = 0; i <= nNumbers - 1; i++)
                {
                    sgn = rand.Next(51) == 1 ? "-" : "";
    
                    if (rand.Next(4) == 1)
                    {
                        values[i] = sgn + (rand.NextDouble() * 100).ToString();
                    }
                    else
                    {
                        values[i] = sgn + rand.Next(100);
                    }
                }
            }
    
            static void ConvertSimple()
            {
                for (int i = 0; i <= nNumbers - 1; i++)
                {
                    file[i] = Math.Abs(Math.Round(double.Parse(values[i]), MidpointRounding.ToEven)).ToString();
                }
            }
    
            static void ConvertLookingAtString()
            {
                for (int i = 0; i <= nNumbers - 1; i++)
                {
                    if (values[i].IndexOf('.') >= 0)
                    {
                        file[i] = Math.Abs(Math.Round(double.Parse(values[i]), MidpointRounding.ToEven)).ToString();
                    }
                    else
                    {
                        file[i] = values[i].TrimStart('-');
                    }
    
                }
    
            }
    
            static void ParallelConvertLookingAtString()
            {
                Parallel.For(0, nNumbers, i =>
                {
                    if (values[i].IndexOf('.') >= 0)
                    {
                        file[i] = Math.Abs(Math.Round(double.Parse(values[i]), MidpointRounding.ToEven)).ToString();
                    }
                    else
                    {
                        file[i] = values[i].TrimStart('-');
                    }
    
                });
    
            }
    
            static void Main()
            {
                Console.Write("Init...");
                Init();
                Console.WriteLine("Done");
    
                Stopwatch sw = new Stopwatch();
    
                // run each test twice
    
                for (int testNum = 0; testNum < 2; testNum++)
                {
                    sw.Reset();
                    sw.Start();
                    ConvertSimple();
                    sw.Stop();
                    Console.WriteLine("Simple\n" + sw.ElapsedMilliseconds.ToString());
    
                    sw.Reset();
                    sw.Start();
                    ConvertLookingAtString();
                    sw.Stop();
                    Console.WriteLine("LookingAtString\n" + sw.ElapsedMilliseconds.ToString());
    
                    sw.Reset();
                    sw.Start();
                    ParallelConvertLookingAtString();
                    sw.Stop();
                    Console.WriteLine("ParallelConvertLookingAtString\n" + sw.ElapsedMilliseconds.ToString());
                }
    
                Console.ReadLine();
    
            }
        }
    }
    
