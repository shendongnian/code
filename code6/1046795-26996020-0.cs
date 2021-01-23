    public static string Reverse(string t)
        {
            char[] charArray = t.ToCharArray();
            string a = "";
            for (int i = 0; i <= charArray.Length;i++ )
            {
                if (!charArray[i].ToString().ToLowerInvariant().Contains(@"^[א-ת]+$"))
                {
                    char[] temp = new char[charArray.Length];
                    for (int k = 0; k < i; k++)
                    {
                        temp[k] = charArray[k];
                    }
                    Array.Reverse(temp);
                    a += temp;
                    a += charArray[i];
                }
            }
                
            return a;
        }
