    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace Demo
    {
        class Program
        {
            void run()
            {
                var test = DuplicateOddNumbers(Enumerable.Range(1, 10));
                foreach (var n in test)
                    Console.WriteLine(n);
            }
            public IEnumerable<int> DuplicateOddNumbers(IEnumerable<int> sequence)
            {
                foreach (int n in sequence)
                {
                    if ((n & 1) == 1)
                        yield return n;
                    yield return n;
                }
            }
            static void Main(string[] args)
            {
                new Program().run();
            }
        }
    }
