    using System;
    using System.Linq;
    
    class Test
    {
        static void Main()
        {
            var numbers = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var filtered = numbers.Where(x => {
                Console.WriteLine("Testing {0}", x);
                return x % 2 == 0;
            });
            Console.WriteLine("Just before loop");
            foreach (var item in filtered)
            {
                Console.WriteLine("Received {0}", item);
            }
        }
    }
