    class Program
        {
            public static bool IsPalindrome(string text)
            {
                if (text.Length <= 1)
                    return true;
                else
                {
                    if (text[0] != text[text.Length - 1])
                        return false;
                    else
                        return IsPalindrome(text.Substring(1, text.Length - 2));
                }
            }
    
    
            public static void Main()
            {
                var x = 545;
                var y = 548785445;
                Console.WriteLine(IsPalindrome(x.ToString()));
                Console.WriteLine(IsPalindrome(y.ToString()));
            }
        }
