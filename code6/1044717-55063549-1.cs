    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    public class Program
    {
        public static Random random;
        public static List<int> lottoNumbers = Enumerable.Range(1, 49).ToList();
        public static void Main()
        {
            random = new Random((int)DateTime.Now.Ticks);
            
            var LinesToGenerate = 10;
            
            GenerateNumbers(LinesToGenerate);
        }
    
        public static void GenerateNumbers(int LineCount)
        {
            int[] SelectedNumbers = new int[6];
            for (var i = 0; i < 6; i++)
            {
                var number = GetRandomNumber(lottoNumbers.ToArray());
                while (SelectedNumbers.Contains(number))
                    number = GetRandomNumber(lottoNumbers.ToArray());
                SelectedNumbers[i] = number;
            }
    
            var numbersOrdered = SelectedNumbers.OrderBy(n => n).Select(n => n.ToString().PadLeft(2, '0'));
            Console.WriteLine(string.Join(" ", numbersOrdered));
            
            if (LineCount > 1)
                GenerateNumbers(--LineCount);
        }
    
        //Recursively and randomly removes numbers from the array until only one is left, and returns it
        public static int GetRandomNumber(int[] arr)
        {
            if (arr.Length > 1)
            {
                //Remove random number from array
                var r = random.Next(0, arr.Length);
                var list = arr.ToList();
                list.RemoveAt(r);
                return GetRandomNumber(list.ToArray());
            }
    
            return arr[0];
        }
    }
