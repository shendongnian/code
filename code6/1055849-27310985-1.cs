    List<string> pros = new List<string>();
    using (var web = new WebClient())
    {
        web.Encoding = System.Text.Encoding.UTF8;
        var jsonString = responseFromServer;
        var jss = new JavaScriptSerializer();
        var result = jss.Deserialize<Top>(jsonString);
        int i = 1;
        foreach (IDs x in result.entries)
        {                        
            pros.Add(x.playerId);
            i++;
            if (i == 3)
            {
                break;
            }
        }
    }
