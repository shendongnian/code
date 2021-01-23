    List<string> arr = new List<string>();
    StreamReader r = File.OpenText( Server.MapPath("b.txt"));
    while (!r.EndOfStream)
    {
       Match match = Regex.Match(r.ReadLine(), @"(www.|http://)([\w.]+)$");
       if (match.Success)
       {
         arr.Add(Regex.Replace(match.Value, @"(http://|www.)", ""));
       }
    }
    ListBox1.DataSource = arr.Distinct();
    ListBox1.DataBind();
