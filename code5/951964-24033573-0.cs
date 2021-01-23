        static void Main(string[] args)
        {
            string data = "ABCDABCDABCDABCD";
            Console.WriteLine(StrangeSubstring(data,4, 1));
            Console.WriteLine(StrangeSubstring(data,4, 2));
            Console.WriteLine(StrangeSubstring(data,4, 3));
           
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
