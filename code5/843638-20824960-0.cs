    using System;
    using System.Collections.Generic;
    using System.Threading;
    namespace Threading001
    {
      class Program
      {
        static void Main(string[] args)
        {
            int total = 0;
			Thread thread = new Thread(() => {
				for ( int j=0 ; j < 1000000 ; j++)
                {
					Interlocked.Add(ref total, 1);
					//total++; //not thread-safe
                }
			});
			thread.Start();
			for ( int i=0 ; i < 1000000 ; i++)
            {
				Interlocked.Add(ref total, 1);
				//total++; //not thread-safe
            }
			thread.Join();
			Console.WriteLine(total);
        }
      }
    }
   
