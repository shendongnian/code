    public static string ReplaceFirst(string str, string search, string newText)
    {
           int ind = str.IndexOf(search);
           if (ind < 0)
           {
               return str;
           }
           return str.Substring(0, ind) + newText + str.Substring(ind + search.Length);
    }
