        static void Main(string[] args)
        {
            string data = "ABCDABCDABCDABCD";
            Console.WriteLine(StrangeSubstring(data,4, 1));
            // "AAAA"
            Console.WriteLine(StrangeSubstring(data,4, 2));
            // "ABABABAB"
            Console.WriteLine(StrangeSubstring(data,4, 3));
            // "ABCABCABCABC"
        }
        static string StrangeSubstring(string input, int modulo, int length)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < input.Length; ++i)
            {
                if (i % modulo == 0)
                {
                    for (int j = 0; j<length; ++j)
                    {
                        if (i+j < input.Length)
                            sb.Append(input[i+j]);
                    }
                }
            }
            return sb.ToString();
        }
