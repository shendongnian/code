    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            const int chunkSize = 50;
            static void Main(string[] args)
            {
                var bigList = Enumerable.Range(0, 10000).Select(s => s).ToList();
    
                ChunkerProcess(bigList, i => { Console.WriteLine(i); });
            }
    
            private static void ChunkerProcess<T>(List<T> bigList, Action<T> action )
            {
                int pointer = 0;
                List<T> chunks = bigList.GetRange(chunkSize * (pointer++), chunkSize);
                while (chunks.Count > 0)
                {
                    foreach (var chunk in chunks)
                    {
                        action.Invoke(chunk);
                    }
                    try
                    {
                        chunks = bigList.GetRange(chunkSize * (pointer++), chunkSize);
                    }
                    catch (Exception ex)
                    {
                        chunks.Clear();
                    }
                }
            }
        }
    }
