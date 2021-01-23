    using System;
    using System.IO;
    using System.Reactive.Linq;
    
    namespace ConsoleApplication8
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                var o = Directory.GetFiles(@"e:\code", "*.*", SearchOption.AllDirectories).ToObservable();
                o.Subscribe(f => Console.WriteLine(f));
    
    
                Console.Read();
            }
        }
    }
