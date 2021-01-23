    public static string Reverse(string t)
        {
            char[] charArray = t.ToCharArray();
            string a = "";
            int last = 0;
            for (int i = 0; i <= charArray.Length-1; i++)
            {
                
                if (!IsHebrew(charArray[i]))
                {
                    List<char> temp = new List<char>();
                    temp.Clear();
                    for (; last < i; last++)
                    {
                        int k = 0;
                        temp.Add (charArray[last]);
                    }
                    temp.Reverse();
                    foreach(char g in temp)
                    {
                        a += g.ToString();
                    }
                    a += charArray[i];
                    last += 1;
                }
            }
            return a;
        }
        private const char FirstHebChar = (char)1488; //א
        private const char LastHebChar = (char)1514; //ת
        private static bool IsHebrew(char c)
        {
            return c >= FirstHebChar && c <= LastHebChar;
        }
