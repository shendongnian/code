    using System.IO;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    
    class Program
    {
        static void Main()
        {
            ArrayList numbers = new ArrayList() {100, 100, 200, 201, 202};
            HashSet<int> uniqueNumbers = new HashSet<int>();
            foreach(int number in numbers) {
                uniqueNumbers.Add(number);
            }
            foreach(int number in uniqueNumbers) {
                Console.WriteLine(number);
            }
            
        }
    }
