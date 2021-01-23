    List<string> _list = new List<string>();
    string temp = @"sadf/*slkdj*/";
    if (temp.StartsWith(@"/*")) { }
    else if (temp.EndsWith(@"*/") && temp.Contains(@"/*"))
    {
        string pre = temp.Substring(0, temp.IndexOf('/'));
        _list.Add(pre);
    }
    else
    {
        _list.Add(temp);
    }
