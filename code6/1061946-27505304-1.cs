    WebClient webClient = new WebClient()) 
    { 
      webClient.Proxy = new WebProxy("myproxy.com"); 
      result= webClient.DownloadString(someURL);
    }
