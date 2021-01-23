    List<string> arr = new List<string>();
    StreamReader r = File.OpenText( Server.MapPath("b.txt"));
    while (!r.EndOfStream)
    {
            string s = r.ReadLine();
            if (s.Contains("http://"))
            {
                s = s.Substring(s.IndexOf("http://"), s.Length - s.IndexOf("http://"));
                arr.Add(s.Replace("http://", ""));
            }
            else if (s.Contains("www."))
            {
                s = s.Substring(s.IndexOf("www."), s.Length - s.IndexOf("www."));
                arr.Add(s.Replace("www.", ""));
            }            
     }
     ListBox1.DataSource = arr.Distinct();
     ListBox1.DataBind();
