    namespace ConsoleApplication2
    {
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Reactive.Linq;
    
        internal class Program
        {
            #region Constants
    
            private const int chunkSize = 50;
    
            #endregion
    
            #region Methods
    
            private static void Main(string[] args)
            {
                List<string> bigList = Enumerable.Range(0, 99).Select(s => s.ToString()).ToList();
                bigList.ToObservable().Buffer(chunkSize).Subscribe(
                    chunk =>
                    {
                        foreach (string s in chunk)
                        {
                            Console.WriteLine(s);
                        }
                        Console.WriteLine(String.Empty.PadRight(80, '-'));
                    });
            }
    
            #endregion
        }
    }
