    // Get the object used to communicate with the server.
    FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://www.contoso.com/test.htm");
    request.Method = WebRequestMethods.Ftp.DownloadFile;
    
    // This example assumes the FTP site uses anonymous logon.
    request.Credentials = new NetworkCredential ("anonymous","janeDoe@contoso.com");
    
    FtpWebResponse response = (FtpWebResponse)request.GetResponse();
        
    Stream responseStream = response.GetResponseStream();
    using (var zip = new ZipArchive(responseStream , ZipArchiveMode.Read))
    {
       //Loops through each file in the zip that has the ".xml" extension 
       foreach (var entry in zip.Entries.Where(x=> (Path.GetExtension(x.Name) ?? "").ToLower() ==".xml"))
       {
            using (var stream = entry.Open())
            {
                //Load xml file and do whatever you like with it.
                var xmlDocument = XDocument.Load(stream);
            }
        }
    }
    
    Console.WriteLine("Download Complete, status {0}", response.StatusDescription);
        
    response.Close();  
