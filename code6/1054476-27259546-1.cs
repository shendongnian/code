    using System;
    using System.Collections.Concurrent;
    using System.Threading;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                //The writer lives in another thread.
                var s = new Thread(ConsoleWriter);
                s.Start();
    
                for (var z = 0; true; z++)
                {
                    //This add call does not get blocked when Console.WriteLine gets blocked.
                    LinesToWrite.Add(z.ToString());
                    Thread.Sleep(200);
                }
            }
    
            static void ConsoleWriter()
            {
                foreach (var line in LinesToWrite.GetConsumingEnumerable())
                {
                    //This will get blocked while you hold down the scroll bar but
                    // when you let go it will quickly catch up.
                    Console.WriteLine(line);
                }
            }
    
            static readonly BlockingCollection<string> LinesToWrite = new BlockingCollection<string>(); 
        }
    }
