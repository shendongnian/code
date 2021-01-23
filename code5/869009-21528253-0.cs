    try {
      FtpWebRequest req = (FtpWebRequest)WebRequest.Create("ftp path");
      req.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
    
      using (FtpWebResponse resp = (FtpWebResponse)req.GetResponse()) {
        Console.WriteLine(resp.WelcomeMessage);
    
        using (StreamReader reader = new StreamReader(resp.GetResponseStream())) {
          Console.WriteLine(reader.ReadToEnd());
          Console.WriteLine("Directory is complete, status(0)", resp.StatusDescription);
        }
      }
    catch (Exception ex) { // <- Bad idea to catch all possible exceptions
      Console.WriteLine(ex.Message);
    }
