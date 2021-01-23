    public List<string> LCS(string firstString, string secondString)
    {
        // to create the lcs table easier which has first row and column empty.
        string firstStringTemp = " " + firstString;
        string secondStringTemp = " " + secondString;
        // create the table
        List<string>[,] temp = new List<string>[firstStringTemp.Length, secondStringTemp.Length];
        // loop over all items in the table.
        for (int i = 0; i < firstStringTemp.Length; i++)
        {
            for (int j = 0; j < secondStringTemp.Length; j++)
            {
                temp[i, j] = new List<string>();
                if (i == 0 || j == 0) continue;
                if (firstStringTemp[i] == secondStringTemp[j])
                {
                    var a = firstStringTemp[i].ToString();
                    if (temp[i - 1, j - 1].Count == 0)
                    {
                        temp[i, j].Add(a);
                    }
                    else
                    {
                        foreach (string s in temp[i - 1, j - 1])
                        {
                            temp[i, j].Add(s + a);
                        }
                    }
                }
                else
                {
                    List<string> b = temp[i - 1, j].Concat(temp[i, j - 1]).Distinct().ToList();
                    if (b.Count == 0) continue;
                    int max = b.Max(p => p.Length);
                    b = b.Where(p => p.Length == max).ToList();
                    temp[i, j] = b;
                }
            }
        }
        return temp[firstStringTemp.Length - 1, secondStringTemp.Length - 1];
    }
