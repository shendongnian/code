    List<string> _list = new List<string>();
    Regex r = new Regex("/[*]");
    string temp = @"sadf/*slkdj*/";
    if (temp.StartsWith(@"/*")) { }
    else if (temp.EndsWith(@"*/") && temp.Contains(@"/*"))
    {
        string pre = temp.Substring(0, r.Match(temp).Index);
        _list.Add(pre);
    }
    else
    {
        _list.Add(temp);
    }
