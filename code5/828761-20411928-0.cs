            static void Main(string[] args)
            {
                string s = "    this is a string";
                Console.WriteLine(count(s));
            }
    
            static int count(string s)
            {
                int total = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == ' ')
                        total++;
                    else
                        break;
                }
                return total;
            }
