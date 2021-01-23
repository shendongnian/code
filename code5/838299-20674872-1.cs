    using System;
    using System.Text;
    
    class Program
    {
        static void Main(string[] args)
        {
            var first = "μ";
            var second = "µ";
    
            var firstNormalized = first.Normalize(NormalizationForm.FormKD);
            var secondNormalized = second.Normalize(NormalizationForm.FormKD);
    
            Console.WriteLine(first.Equals(second));                     // False
            Console.WriteLine(firstNormalized.Equals(secondNormalized)); // True
        }
    }
