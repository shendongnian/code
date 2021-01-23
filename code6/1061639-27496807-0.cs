    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace LottoSample
    {
        class Program
        {
            static void Main(string[] args)
            {
                Random random = new Random();
    
                // Dictionary to store list of random numbers.
                // It accepts an integer as a key, and a bool as a dummy place holder.
                // The place holder is never used but a dictionary needs a value of some kind.
                Dictionary<int, bool> _lottoNumbers = new Dictionary<int, bool>();
    
                // Total amount of numbers
                int count = 50;
    
                while (count > 0)
                {
                    // Attempt to add a new random number into the dictionary of lotto numbers and reduce count by 1
                    try
                    {
                        _lottoNumbers.Add(random.Next(1, 100), true);
                        count--;
                    }
                    catch
                    {
                        // Dictionaries and HashSets don't allow duplicate keys by default.
                        // When an attempt to add a duplicate is found, an exception is thrown.
                        // We simply ignore it. Because we still want X number of random numbers,
                        // we don't bother reducing the counter unless it succeeds.
                    }
                }
    
                // Print the result
                foreach (var num in _lottoNumbers.Keys)
                    Console.WriteLine(num);
    
                // Prevent the console window from closing
                Console.ReadLine();
            }
        }
    }
