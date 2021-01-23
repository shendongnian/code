            string s1 = "This city is very beautiful";
            string s2 = "The citi is very beautyful - and its also very big:";
            if (!string.IsNullOrEmpty(s2) && s2.Contains(' '))
            {
                string[] partsS1 = s1.Split(' ');
                string[] partsS2 = s2.Split(' ');
                int count = partsS1.Length;
                for (int a = 0; a < count; a++)
                {
                    if (partsS2.Length > count)
                    {
                        if (partsS1[a] != partsS2[a])
                        {
                            partsS2[a] = partsS1[a];
                        }
                    }
                }
                string final = string.Empty;
                foreach (string s in partsS2)
                {
                    final += s + " ";
                }
                final = final.TrimEnd(' ');
                Console.WriteLine(final);
            }
