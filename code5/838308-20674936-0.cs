    using System;
    using System.Text;
    
    class Program
    {
        static void Main(string[] args)
        {
            var first = 'μ';
            var second = 'µ';
                
            var firstNormalChar = first.ToString().Normalize(NormalizationForm.FormKD);
            var secondNormalChar = second.ToString().Normalize(NormalizationForm.FormKD);
    
            Console.WriteLine(first.Equals(second));                     // False
            Console.WriteLine(firstNormalChar.Equals(secondNormalChar)); // True
        }
    }
