    public static void LCS(char[] str1, char[] str2)
        {
            int[,] l = new int[str1.Length, str2.Length];
            int lcs = -1;
            string substr = string.Empty;
            int end = -1;
            
            for (int i = 0; i < str1.Length; i++)
            {
                for (int j = 0; j < str2.Length; j++)
                {
                    if (str1[i] == str2[j])
                    {
                        if (i == 0 || j == 0)
                        {
                            l[i, j] = 1;
                        }
                        else
                            l[i, j] = l[i - 1, j - 1] + 1;
                        if (l[i, j] > lcs)
                        {
                            lcs = l[i, j];
                            end = i;
                        }
    
                    }
                    else
                        l[i, j] = 0;
                }
            }
    
            for (int i = end - lcs + 1; i <= end; i++)
            {
                substr += str1[i];
            }
            
            Console.WriteLine("Longest Common SubString Length = {0}, Longest Common Substring = {1}", lcs, substr);
        } 
