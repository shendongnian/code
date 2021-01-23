    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    namespace StackOverflow
    {
        class Program
        {
            static void Main(string[] args)
            {
                new Program();
                Console.WriteLine("done");
                Console.ReadKey();
            }
            Program()
            {
                int noThreads = 5;
                int target = 2000;
                StartThread(noThreads, target);
            }
            //kicks off our threads / waits for all threads to complete before returning
            void StartThread(int noThreads, int target)
            {
                int id = noThreads--;
                if (id > 0)
                {
                    Doer doer = new Doer(id, target);
                    Thread t = new Thread(doer.Do);
                    t.Start();
                    StartThread(noThreads,target);
                    t.Join();
                }
            }
        
        }
        class Doer 
        {
            static int marker = 0;
            static readonly object syncLocker = new object();
            readonly int id;
            readonly int target;
            public Doer(int id, int target)
            {
                this.id = id;
                this.target = target;
            }
            public void Do() 
            {
                while (marker < this.target)
                {
                    int i;
                    lock (syncLocker)
                    {
                        i = ++marker;
                    }
                    System.Console.WriteLine("{0:00}: {1:###0}", id, i);
                    //Thread.Sleep(RandomNo()); //uncomment this & code below if your threads are taking turns / behaving too predictably
                }
            }
            /*
            static readonly Random rnd = new Random();
            static readonly object rndSyncLocker = new object();
            public static int RandomNo()
            {
                lock (rndSyncLocker)
                {
                    return rnd.Next(0, 1000); 
                }
            }
            */
        }
    }
