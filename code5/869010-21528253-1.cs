    try {
      FtpWebRequest req = (FtpWebRequest)WebRequest.Create("ftp path");
      req.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
    
      // Response: we're going to work wuth respose within "using" block only
      using (FtpWebResponse resp = (FtpWebResponse)req.GetResponse()) {
        Console.WriteLine(resp.WelcomeMessage);
    
        // Reader: once again reader's opened once and called within using only
        using (StreamReader reader = new StreamReader(resp.GetResponseStream())) {
          Console.WriteLine(reader.ReadToEnd());
          Console.WriteLine("Directory is complete, status(0)", resp.StatusDescription);
        }
      }
    catch (Exception ex) { // <- Bad idea to catch all possible exceptions without "throw;"
      Console.WriteLine(ex.Message);
    }
