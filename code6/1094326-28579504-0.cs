    using System;
    using System.Linq;
    
    namespace PasswordCheck
    {
        class Program
        {
            static void Main(string[] args)
            {
                CheckPasswordComplexity("abc");
                CheckPasswordComplexity("aB1#");
                CheckPasswordComplexity("ABCc");
            }
    
            static private void CheckPasswordComplexity(string text)
            {
                var hasUpperCase = text.Any(char.IsUpper);
                var hasLowerCase = text.Any(char.IsLower);
                var hasDigits = text.Any(char.IsDigit);
                var hasPuncutation = text.Any(char.IsPunctuation); // Convers more than your case. Check here: http://www.dotnetperls.com/char-ispunctuation
    
                if (!hasUpperCase)
                {
                    Console.WriteLine("No upper case character found");
                }
                else if (!hasLowerCase)
                {
                    Console.WriteLine("No lower case character found");
                }
                else if (!hasDigits)
                {
                    Console.WriteLine("No digit found");
                }
                else if (!hasPuncutation)
                {
                    Console.WriteLine("No special character found");
                }
                else
                {
                    Console.WriteLine("ALL Ok");
                }
            }
        }
