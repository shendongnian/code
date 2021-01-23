            static void Main(string[] args)
            {
                string s = " acv jk   ik  ";
                Console.WriteLine("Total space: {0}", CountSpace(s));
                Console.ReadLine();
            }
    
            private static int CountSpace(string s)
            {
                if (s.Length > 1)
                    return s[0] == ' ' ? 1 + CountSpace(s.Substring(1, s.Length - 1)) : CountSpace(s.Substring(1, s.Length - 1));
                return s[0] == ' ' ? 1 : 0;
            }
