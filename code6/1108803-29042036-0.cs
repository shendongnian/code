    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			int ArrSize = 100000000;
    
    			Stopwatch sw2 = new Stopwatch();
    
    			int[] test2 = new int[ArrSize];
    			int[] test3 = new int[ArrSize];
    			int[] test4 = new int[ArrSize];
    			
    			Random randNum = new Random();
    
    			sw2.Start();
    
    			for (int i = 0; i < test2.Length; i++)
    			{
    				test2[i] = i;
    			}
    
    			sw2.Stop();
    
    			Console.WriteLine("Linear elapsed:          {0}", sw2.Elapsed);
    
    			sw2.Restart();
    
    			Parallel.For(0, test3.Length, (j) =>
    			{
    				test3[j] = j;
    			}
    				);
    
    			sw2.Stop();
    
    			Console.WriteLine("Simple parallel elapsed: {0}", sw2.Elapsed);
    
    			sw2.Restart();
    
    			var rangePartitioner = Partitioner.Create(0, test4.Length);
    			Parallel.ForEach(rangePartitioner, (range, loopState) =>
    			{
    				for (int j = range.Item1; j < range.Item2; j++)
    				{
    					test4[j] = j;
    				}
    			});
    			
    			sw2.Stop();
    
    			Console.WriteLine("Partitioned elapsed:     {0}", sw2.Elapsed);
    
    			Console.ReadLine();
    
    		}
    	}
    }
    
