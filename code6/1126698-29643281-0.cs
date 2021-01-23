    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApplication1
    {
     
        class Program
        {
            static void Main(string[] args)
            {
                var myQueue = new Queue<int>();
                myQueue.Enqueue(6);
                myQueue.Enqueue(3000);
                myQueue.Enqueue(1000);
                myQueue.Enqueue(-304);
    
                Console.WriteLine("Min: {0}", myQueue.MyMin());
                myQueue.Display();
                Console.ReadLine();
            }
        }
    
        static class QueueExtensionMethods
        {
            //Renamed to MyMin because Min already exists from System.Linq
            public static T MyMin<T>(this Queue<T> queue)
            {
                bool notSupport = false;
                try
                {
                    T minItem = queue.First();
                    foreach (T temp in queue)
                    {
                        try
                        {
                            if (Convert.ToDouble(minItem) > Convert.ToDouble(temp))
                                minItem = temp;
                        }
                        catch
                        {
                            notSupport = true;
    
                        }
                    }
                    return minItem;
                }
                catch
                {
                    if (notSupport)
                        throw (new InvalidOperationException("Error: Method not support this type."));
                    else
                        throw (new InvalidOperationException("Error: Queue is empty"));
                }
            }
    
            public static void Display<T>(this Queue<T> queue)
            {
                foreach (T item in queue)
                {
                    Console.Write(item);
                    Console.Write("-->");
                }
                Console.WriteLine();
            }
        }
    }
