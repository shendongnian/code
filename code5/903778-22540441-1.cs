    public static string[] SplitBy(this string source,char separator)
    {
        var chars = source.ToCharArray();
        var temp = new List<char>();
        var words = new List<string>();
        bool splitControl = false;
        for (int i = 0; i < chars.Length; i++)
        {
            if (chars[i] == separator && !splitControl)
            {
               splitControl = true;
               continue;
            }
            else if (chars[i] == separator && splitControl)
            {
               words.Add(new string(temp.ToArray()));
               temp.Clear();
               splitControl = false;
               continue;
            }
            if(splitControl) temp.Add(chars[i]);
        }
        if(temp.Any()) words.Add(new string(temp.ToArray()));
        return words.ToArray();
    }
