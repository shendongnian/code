    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace ConsoleApp1
    {
        sealed class Item
        {
            public int Number1;
            public int Number2;
            public override string ToString()
            {
                return string.Format("Number1 = {0}, Number2 = {1}", Number1, Number2);
            }
        }
        class Program
        {
            private void run()
            {
                var data = createTestData();
                var sort1 = Enumerable.Range(0, data.Count).ToArray(); // Indices to use to sort list by Number1.
                var sort2 = Enumerable.Range(0, data.Count).ToArray(); // Indices to use to sort list by Number1.
                Array.Sort(sort1, (a, b) => (data[a].Number1 - data[b].Number1));
                Array.Sort(sort2, (a, b) => (data[a].Number2 - data[b].Number2));
                Console.WriteLine("Original data:");
                foreach (var element in data)
                    Console.WriteLine(element);
                Console.WriteLine("\nSorted by Number1:");
                foreach (var index in sort1)
                    Console.WriteLine(data[index]);
                Console.WriteLine("\nSorted by Number2:");
                foreach (var index in sort2)
                    Console.WriteLine(data[index]);
            }
            static List<Item> createTestData()
            {
                return new List<Item>
                {
                    new Item {Number1 = 2, Number2 = 3},
                    new Item {Number1 = 1, Number2 = 4},
                    new Item {Number1 = 4, Number2 = 1},
                    new Item {Number1 = 7, Number2 = 6},
                    new Item {Number1 = 5, Number2 = 7},
                    new Item {Number1 = 6, Number2 = 5},
                    new Item {Number1 = 3, Number2 = 2},
                };
            }
            static void Main()
            {
                new Program().run();
            }
        }
    }
