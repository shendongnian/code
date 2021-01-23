    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace primefinder2
    {
        class Program
        {
            static void Main(string[] args)
            {
                //edited version of Alexander Ameye's code (https://stackoverflow.com/users/4014883/alexander-ameye)
                HashSet<int> NoPrime = new HashSet<int>();
            long count = 0;
            Console.WriteLine("please enter a max search value");
            bool input = int.TryParse(Console.ReadLine(), out int n);
            while (input == false)
            {
                Console.WriteLine($"{input} is not a valid value.\nPlease enter a valid number");
                input = int.TryParse(Console.ReadLine(), out n);
            }
            string name = $"Primes_to_{n}";
            string filename = String.Format("{0:yyyy-MM-dd-hh-mm}__{1}", DateTime.Now, name);
            for (int x = 2; x < n; x++)
            {
                for (int y = x * 2; y < n; y = y + x)
                {
                    if (!NoPrime.Contains(y))
                    {
                        NoPrime.Add(y);
                    }
                }
            }
            for (int z = 2; z < n; z++)
            {
                if (!NoPrime.Contains(z))
                {
                    Console.WriteLine(z);
                    using (System.IO.StreamWriter file =
            new System.IO.StreamWriter($@"{filename}.csv", true))
                    {
                        file.WriteLine(z);
                    }
                    count = count + z;
                }
            }
            Console.WriteLine($"Sum is: {count}");
            Console.ReadLine();
        }
    }
    }
