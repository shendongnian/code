    public string TestCSV(string id)
        {
        List<string> splitted = new List<string>();
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://mywebsite.com/data.csv");
        HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
        using (StreamReader sr = new StreamReader(resp.GetResponseStream()))
        {
        string currentline = sr.ReadLine();
        if (currentline != string.IsNullOrWhiteSpace)
        {
            var res = currentline.Split(new char[] { ',' });
            if (res[0] == id)
            {
                splitted.Add(res[1]);
            }
            foreach (var line in splitted)
            {
                return line;
            } 
         }
      }
     return null;
    }
