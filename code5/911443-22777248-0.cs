    String s = "dr. david BOWIE md";
    s= ConvertToMyCase(s);
    public string ConvertToMyCase(string s)
    {
      s = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(s.toLower());
      List<string> my = new List<string>();
      string[] separators = new string[] {",", ".", "!", "\'", " ", "\'s"};
      foreach (string word in s.Split(separators, StringSplitOptions.RemoveEmptyEntries))
      {
        if(s.Length == 2)
        {
           word.ToUpper();
        }
      }
    return s;
    }
