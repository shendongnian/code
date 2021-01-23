    List<string> arr = new List<string>();
    StreamReader r = File.OpenText( Server.MapPath("b.txt"));
    while (!r.EndOfStream)
    {
      string s = r.ReadLine();
      if (s.Contains("http://") || s.Contains("www"))
      {
        string str = s.Contains("http://") ? "http://" : "www.";
        arr.Add(s.Substring(s.IndexOf(str), s.Length - s.IndexOf(str)).Replace(str, ""));
      }      
    }
    ListBox1.DataSource = arr.Distinct();
    ListBox1.DataBind();
