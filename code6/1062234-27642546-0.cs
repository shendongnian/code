        static void Main(string[] args)
        {
            string input = "1555454545445.20000000000000000";
            StringBuilder sb = new StringBuilder(input);
            for (int i = 0; i < input.Length-2; i++)
            {
                if (input[i] == '.')
                {
                    if (input[input.Length - 1] == '0')
                    {
                        for (int x = 0; x < input.Length - i; i++)
                        {
                            if (sb[sb.Length - 1] == '0') 
                            {
                                sb = sb.Remove((sb.Length - 1), 1);
                            }
                        }
                    }
                }
            }
            Console.WriteLine(input);
            Console.WriteLine(sb.ToString());
        }
