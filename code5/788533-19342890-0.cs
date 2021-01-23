    using System;
    using System.Collections.Generic;
    using System.Threading;
    namespace TimedFetch
    {
        class Program
        {
            static System.Threading.Timer workTimer;
            static Stack<string> itemList;
            public static AutoResetEvent fetchDataEvent;
            static int eventCounter;
            public class ExternalDatamanager
            {
                public void FetchData()
                {
                    DateTime startTime = DateTime.Now;
                    do
                    {
                        FetchHeaderData();
                        fetchDataEvent.WaitOne();
                        Console.WriteLine("{0} FetchData Signaled! List size {1}", DateTime.Now.ToLongTimeString(), itemList.Count);
                    } while(true);
                }
                private static void FetchHeaderData()
                {
                    // replace this with your method of retrieving data
                    Console.WriteLine("{0} FetchHeaderData", DateTime.Now.ToLongTimeString());
                    DateTime timeObject = DateTime.Now;
                    for (int i = 0; i < 30; i++)
                    {
                        lock (itemList)
                        {
                            itemList.Push(timeObject.ToLongTimeString());
                            timeObject = timeObject.AddSeconds(1);
                        }
                   }
                }
            }
            static void Main(string[] args)
            {
                eventCounter = 0;
                itemList = new Stack<string>();
                fetchDataEvent = new AutoResetEvent(false);
                ExternalDatamanager dataManager = new ExternalDatamanager();
                Thread workerThread = new Thread(new ThreadStart(dataManager.FetchData));
                workerThread.Start();
                workTimer = new System.Threading.Timer(workTimer_Elapsed, null, 0, 1000);
            }
            // executes once a second
            private static void workTimer_Elapsed(Object state)
            {
                Console.WriteLine("{0} Fire!", DateTime.Now.ToLongTimeString());
                Interlocked.Increment(ref eventCounter);
                lock (itemList)
                {
                    // every 10 seconds
                    if (itemList.Count > 0)
                        FetchDetail(itemList.Pop());
                    // else ??
                    // { ??
                    if (eventCounter % 10 == 0)
                        fetchDataEvent.Set();
                    // } ??
                }
            }
            private static void FetchDetail(string headerRecord)
            {
                Console.WriteLine("{0} Fetch detail for {1}", DateTime.Now.ToLongTimeString(), headerRecord);
            }
        }
    }
