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
                Random _random = new Random();
    
                // Dictionary to store list of random numbers
                HashSet<int> _lottoNumbers = new HashSet<int>();
    
                // Total amount of numbers
                int _count = 50;
                int _randomNumber = -1;
    
                while (_count > 0)
                {
                    // Get a random number
                    _randomNumber = _random.Next(1, 100);
    
                    // Check to see if the number already exists
                    if (_lottoNumbers.Contains(_randomNumber) != true)
                    {
                        // It doesn't, so add it
                        _lottoNumbers.Add(_randomNumber);
                        
                        // reduce the count by 1
                        _count--;
                    } 
                }
    
                // Print the result
                foreach (var num in _lottoNumbers)
                    Console.WriteLine(num);
    
                // Prevent the console window from closing
                Console.ReadLine();
            }
        }
    }
