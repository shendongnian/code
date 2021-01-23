    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace LottoSample
    {
        class Program
        {
            const int QTY = 10;
    
            static void Main(string[] args)
            {
                // A lotto numbers object which is initialized with the total amount of random numbers.
                var _lottoNumbers = new LottoNumbers(QTY);
    
                Random _random = new Random();
    
                int _count = QTY;       // Iterator
                int _randomNumber = -1; // Stores the random number
    
                // As long as there is still slots available, add a new random number
                while (_count > 0)
                { 
                    // Get a random number
                    _randomNumber = _random.Next(1, 100);
    
                    // Attempt to add the number to the lotto numbers
                    if (_lottoNumbers.Add(_randomNumber) == true)
                    {
                        // It was successful, reduce the count by 1
                        _count--;
                    }
                    // Otherwise, try again until a unique value is found.
                }
    
                // Display the result
                Console.WriteLine(_lottoNumbers.ToString());
                Console.ReadLine();
            }
    
            public class LottoNumbers
            {
                private HashSet<int> _numbers;
                private int _total;
    
                public LottoNumbers()
                {
                    this._numbers = new HashSet<int>();
                }
    
                public LottoNumbers(int total)
                    : this()
                {
                    _total = total;
                }
    
                public bool Add(int number)
                {
                    // Check to see if the count of numbers is greater than the limit
                    // Throw an exception if so.
                    if (this.Count() >= _total)
                        throw new ArgumentOutOfRangeException();
    
                    // Check to see if the number already exists and return true if so.
                    if (this._numbers.Contains(number))
                        return false;
    
                    // Add the number otherwise and return true.
                    this._numbers.Add(number);
                    return true;
                }
    
                // Overriden ToString() that displays a formatted list of numbers 
                public override string ToString()
                {
                    var sb = new StringBuilder();
                    foreach (var n in _numbers)
                    {
                        sb.AppendFormat("{0}", n);
    
                        // If the number isn't the last in the list, append a comma
                        if (n != _numbers.Last())
                        {
                            sb.Append(",");
                        }
                    }
                        
                    return sb.ToString();
                }
    
                // Get the count of numbers
                private int Count()
                {
                    return this._numbers.Count();
                }
            }
        }
    }
