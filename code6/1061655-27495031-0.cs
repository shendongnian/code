      string url = ConfigurationManager.AppSettings.GetValues("PBHomePage")[0];
      HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(url);
      webReq.ContentType = "text/html";
      Regex regex = new Regex("(<font size=\"6\" color=\"#FFFFFF\"><strong>\\$)(\\d+)(\\.*)(\\d*)(\\s+Million</strong></font>)");
      try
      {
        WebResponse response = webReq.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string webPage = reader.ReadToEnd();
        if (!regex.IsMatch(webPage)) { return null; }
        GroupCollection groups = regex.Match(webPage).Groups;
        StringBuilder strJackpot = new StringBuilder(groups[2].Value);
        if (!string.IsNullOrEmpty(groups[3].Value) && !string.IsNullOrEmpty(groups[4].Value))
        {
          strJackpot.Append(groups[3].Value + groups[4].Value);
        }
        jackpot = double.Parse(strJackpot.ToString());
      }
      catch (WebException ex)
      {
        Console.WriteLine("Error in getting Latest Jackpot");
      }
