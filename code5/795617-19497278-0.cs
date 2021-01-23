    var request = (FtpWebRequest)WebRequest.Create("ftp://example.com/");
    request.Credentials= new NetworkCredential("username", "password");
    // List files
    request.Method = WebRequestMethods.Ftp.ListDirectory;
    
    var resp = (FtpWebResponse) request.GetResponse();
    var stream = resp.GetResponseStream();
    var readStream = new StreamReader(resp.GetResponseStream(), System.Text.Encoding.UTF8);
    
    // handle the incoming stream, store in a List, print, find etc
    var files = new List<String>();
    if (readStream != null)
    {
        while(!readStream.EndOfStream)
    	{
    	  files.Add(readStream.ReadLine());
    	}
    } 
    // showe them
    foreach(var file in files)
    {
       Console.WriteLine(file);
    }
    // find one
    var fileToFind = "Public";
    var foundFile = files.Find( f => f == fileToFind);
    Console.WriteLine("found file {0}:", foundFile);
    // show status
    Console.WriteLine("List status: {0}",resp.StatusDescription); 
