    public static string ExchangeFirstLast(string str)
    {
        var lst = new List<string>();
        var enumerator = StringInfo.GetTextElementEnumerator(str);
        while (enumerator.MoveNext())
        {
            lst.Add(enumerator.GetTextElement());
        }
        if (lst.Count >= 2)
        {
            string temp = lst[0];
            lst[0] = lst[lst.Count - 1];
            lst[lst.Count - 1] = temp;
        }
        string str2 = string.Concat(lst);
        return str2;
    }
