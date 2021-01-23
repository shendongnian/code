    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ParallelLoop
    {
        class Program
        {
    
            static void Main(string[] args)
            {
    
                int Min = 0;
                int Max = 10;
                int ArrSize = 150000000;
    
                Stopwatch sw2 = new Stopwatch();
                Stopwatch sw3 = new Stopwatch();
                Stopwatch sw4 = new Stopwatch();
    
                int[] test2 = new int[ArrSize];
                int[] test3 = new int[ArrSize];
                int[] test4 = new int[ArrSize];
    
                Random randNum = new Random();
    
                sw2.Start();
                for (int i = 0; i < test2.Length; i++)
                {
                    test2[i] = i;
                    //test2[i] = randNum.Next(Min, Max);
                }
                sw2.Stop();
    
                //Console.ReadKey();
                Console.WriteLine("Elapsed={0}", sw2.Elapsed);
    
                sw3.Start();
    
                Parallel.For(0, test3.Length, (j) =>
                {
                    test3[j] = j;
                    //test3[j] = randNum.Next(Min, Max);
                }
                    );
    
                sw3.Stop();
    
                Console.WriteLine("Elapsed={0}", sw3.Elapsed);
    
                sw4.Start();
    
                int numberOfCores = 4;
    
                int itemsPerCore = ArrSize / numberOfCores;
    
                for (int i = 0; i < numberOfCores; i++)
                {
                    int x = i; // for lambda closure
                    var thread = new Thread(new ThreadStart(() =>
                    {
                        int from = itemsPerCore * x;
                        int to = itemsPerCore * (x + 1);
                        for (int j = from; j < to; j++)
                        {
                            test4[j] = j;
                            //test4[j] = randNum.Next(Min, Max);                        
                        }
                    }));
    
                    thread.Start();
                }
    
                sw4.Stop();
    
                Console.WriteLine("Elapsed={0}", sw4.Elapsed);
    
                Console.ReadKey();
            }
        }
    }
