    string[] lines = multilinestring.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
    List<string> validString = new List<string>();
    foreach(string s in lines)
    {
       if(finder.Match(s).Success)
       {
          validString.Add(s);
       }
    }
