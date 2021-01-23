    using System;
    using System.Text;
    
    class Program
    {
        static void Main(string[] args)
        {
            var first = 'μ';
            var second = 'µ';
    
            // Technically you only need to normalize U+00B5 to obtain U+03BC, but
            // if you're unsure which character is which, you can safely normalize both
            var firstNormalized = first.ToString().Normalize(NormalizationForm.FormKD);
            var secondNormalized = second.ToString().Normalize(NormalizationForm.FormKD);
    
            Console.WriteLine(first.Equals(second));                     // False
            Console.WriteLine(firstNormalized.Equals(secondNormalized)); // True
        }
    }
