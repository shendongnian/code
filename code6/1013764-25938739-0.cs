        string a = "acegikmobdfhjln";
            char[] b = a.ToCharArray();
            char t;
            for (int h = 0; h < b.Length; h++)
            {
                for (int i = 0; i <= b.Length - 2; i++)
                {
                    if (b[i] > b[i + 1])
                    {
                        t = b[i + 1];
                        b[i + 1] = b[i];
                        b[i] = t;
                    }
                }
            }
            foreach (char item in b)
                Console.Write(item + " ");
            Console.WriteLine();
            Console.ReadLine();
