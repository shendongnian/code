      string url =  "Your URL";
      System.Net.WebRequest req = System.Net.WebRequest.Create(url);
      req.Proxy = new WebProxy();
      System.Net.WebResponse resp = req.GetResponse();
         
