    string[] SplitMyString(string s)
    {
      if( s.Length == 0 )
        return new string[0];
    
      List<string> split = new List<string>(1);
      split.Add("");
      bool isNumeric = s[0] >= '0' && s[0] <= '9';
      foreach(char c in s)
      {
        bool AddString = false;
        if( c >= '0' && c <= '9' )
        {
          AddString = !isNumeric;
          isNumeric = true;
        }
        else
        {
          AddString = isNumeric;
          isNumeric = false;
        }
        if( AddString )
            split.Add(c.ToString());
        else
          split[split.Count-1] += c;
      }
      return split.ToArray();
    }
