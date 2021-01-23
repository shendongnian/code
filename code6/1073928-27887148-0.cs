    int userid = 1;
    
    Uri resourceUri = new Uri(new Uri(Request.Url.Host), string.Format("XMLHandler.ashx?userId={0}", userid));
    System.Net.WebClient webClient = new System.Net.WebClient();
    string xmlString = webClient.DownloadString(resourceUri);
    // rest of the code is the same
