    static void Main(string[] args)
            {
                string charSet = "0123456789!@#$%^&*";
    
                string password = "20@";
                StringBuilder start = new StringBuilder("0");
                int j = 0;
                int z = 0;
                while (start.ToString() != password)
                {
                    start[z] = charSet[j++];
                    Console.WriteLine(start);
                    if (j == charSet.Length)
                    {
                        if (start.ToString().Where(c => c == charSet[charSet.Length - 1]).Count() == start.ToString().Length)
                        {
                            start.Append("0");
                            for (int t = 0; t < start.Length; t++)
                            {
                                start[t] = '0';
    
                            }
                            z++;
                        }
                        else
                        {
                            for (int t = start.Length - 2; t >= 0; t--)
                            {
                                if (charSet.IndexOf(start[t]) == charSet.Length - 1)
                                {
                                    start[t] = '0';
                                }
                                else
                                {
                                    start[t] = charSet[charSet.IndexOf(start[t]) + 1];
                                    break;
                                }
                            }
                        }
                        j = 0;
                    }
    
                }
            }
