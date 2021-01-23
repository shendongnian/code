    public int compareing(string a, string b)
            {
                char[] one = a.ToLower().ToCharArray();
                char[] two = b.ToLower().ToCharArray();
                int ret = 0;
                for (int i = 0; i < one.Length; i++)
                {
                    for (int j = 0; j < two.Length; j++)
                    {
                        Loop:
                        int val = 0;
                        int val2 = 0;
                        string c = one[i].ToString();
                        char[] c1 = c.ToCharArray();
                        byte[] b1 = ASCIIEncoding.ASCII.GetBytes(c1);
                        string A = two[j].ToString();
                        char[] a1 = A.ToCharArray();
                        byte[] d1 = ASCIIEncoding.ASCII.GetBytes(a1);
                        int sec = d1[0];
                        int fir = b1[0];
                        if (fir > sec)
                        {
                            return ret = 1;
                            break;
                        }
                        else
                        {
                            if (fir == sec)
                            {
                                j = j + 1;
                                i = i + 1;
                                if (one.Length == i)
                                {
                                    return ret = 0;
                                }
                                goto Loop;
                            }
                            else
                            {
                                return 0;
                            }
                        }
                    }
                }
                return ret;
            }
            public void stringcomparision(List<string> li)
            {
                string temp = "";
                for(int i=0;i<li.Count;i++)
                {
                    for(int j=i+1;j<li.Count;j++)
                    {
                        if(compareing(li[i],li[j])>0)
                        {
                            //if grater than it throw 1 else -1
                            temp = li[j];
                            li[j] = li[i];
                            li[i] = temp;
                        }
                    }
                }
                Console.WriteLine(li);
            }
