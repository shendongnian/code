    using System;
    using System.Collections;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication
    {
        // http://stackoverflow.com/q/22852251/1768303
    
        public class Program
        {
            class Resource : IDisposable
            {
                public void Dispose()
                {
                    Console.WriteLine("Resource.Dispose");
                }
    
                ~Resource()
                {
                    Console.WriteLine("~Resource");
                }
            }
    
            private IEnumerator Sleep(int milliseconds)
            {
                using (var resource = new Resource())
                {
                    Stopwatch timer = Stopwatch.StartNew();
                    do
                    {
                        yield return null;
                    }
                    while (timer.ElapsedMilliseconds < milliseconds);
                }
            }
    
            void EnumeratorTest()
            {
                var enumerator = Sleep(100);
                enumerator.MoveNext();
                Thread.Sleep(500);
                //while (e.MoveNext());
                ((IDisposable)enumerator).Dispose();
            }
    
            public static void Main(string[] args)
            {
                new Program().EnumeratorTest();
                GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, true);
                GC.WaitForPendingFinalizers();
                Console.ReadLine();
            }
        }
    }
