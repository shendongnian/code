    public IEnumerable<Tuple<string, int>> SplitWithIndexes(string str, char splitChar)
    {
        StringBuilder ret = new StringBuilder();
        int retStartIndex = 0;
        for (int v = 0; v < str.Length; v++)
        {
             char c = str[v];
             if (c == splitChar)
             {
                 yield return new Tuple<string, int>(ret.ToString(), retStartIndex);
                 ret.Clear();
                 retStartIndex = v + 1;
             }
             else
             {
                 ret.Append(c);
             }
        }
        yield return new Tuple<string, int>(ret.ToString(), retStartIndex);
    }
