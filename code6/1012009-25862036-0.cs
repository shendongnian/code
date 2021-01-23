    class Program
        {
            static void Main(string[] args)
            {
                string test = "abcdef";
                int sum = 0;  
                foreach (char c in test)
                {
                    int letterNumber = char.ToUpper(c) - 64;  
                    sum += rtnDegint(letterNumber);
                }  
                Console.WriteLine(sum);
            }
    
            int rtnDegint(int n)
            {
                int first = 0, second = 1, next = 0, c;  
                for (c = 0; c < n; c++)
                {
                    if (c <= 1)
                        next = c;
                    else
                    {
                        next = first + second;
                        first = second;
                        second = next;
                    }
                }
                return next;
            }
        }
