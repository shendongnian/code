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
                var bigList = Enumerable.Range(0, 10000).Select(s => s.ToString()).ToList();
    
                ChunkerProcess(bigList, i => { Console.WriteLine(i); });
            }
    
            private static void ChunkerProcess<T>(List<T> bigList, Action<T> action )
            {
                int pointer = 0;
                List<T> chunks = bigList.GetRange(0, chunkSize>bigList.Count?bigList.Count:chunkSize);
                while (chunks.Count > 0)
                {
                    foreach (var chunk in chunks)
                    {
                        action.Invoke(chunk);
                    }
                    chunks.Clear();
                    if (chunkSize * pointer < bigList.Count)
                    {
                        chunks = bigList.GetRange(chunkSize * pointer, chunkSize * (pointer + 1) > bigList.Count ? bigList.Count - chunkSize * pointer : chunkSize);
                        pointer++;
                    }
                }
            }
        }
    }
