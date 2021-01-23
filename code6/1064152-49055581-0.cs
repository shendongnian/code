    StringBuilder sb = new StringBuilder();
                string x = "aaaaaaaaaabcccccc";
                char[] c = x.ToCharArray();
                char[] t = c.Distinct().ToArray();
                for (int i = 0; i < t.Length; i++)
                {
                    int count = 0;
                   
                        for (int j = 1; j < c.Length; j++)
                        {  
                                if (t[i] == c[j - 1])
                                {
                                    count++;
                                }
                        }
                       
                    if (count > 1)
                    {
                        sb.Append(t[i] + count.ToString());
                    }
                    else
                    {
                        sb.Append(t[i]);
                    }
    
                }
                Console.Write(sb);
                Console.ReadKey();
       
