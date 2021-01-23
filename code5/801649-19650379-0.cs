    String s = "[TEST name1=\"smith ben\" name2=\"Test\" abcd=\"Test=\" mmmm=\"Test=\"]";
             
    SortedList<string, string> list = new SortedList<string, string>();
             
    //Remove the start and end tags
    s = s.Remove(0, s.IndexOf(' '));
    s = s.Remove(s.LastIndexOf('\"') + 1);
             
    //Split the string
    string[] pairs = s.Split(new char[] { '\"' }, StringSplitOptions.None);
             
    //Add each pair to the list
    for (int i = 0; i+1 < pairs.Length; i += 2)
    {
       string left = pairs[i].TrimEnd('=', ' ');
       string right = pairs[i+1].Trim('\"');
       list.Add(left, right);
    }
