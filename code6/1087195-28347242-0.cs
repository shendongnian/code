    string input = "46 47\n\n48 49";
    
                using (StreamWriter sw = new StreamWriter(@"d:\Software\MyTest.txt", true))
                {
                    foreach (char s in input)
                    {
                        if (s == '\n')
                        {
                            sw.Write(Environment.NewLine);
                        }
                        else
                        sw.Write(s);
                    }
                }
