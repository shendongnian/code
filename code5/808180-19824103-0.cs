    string sURL = "http://api.planets.nu/games/list?limit=1";
    WebRequest wrGetURL = WebRequest.Create(sURL);
    var gzip = new GZipStream(wrGetURL.GetResponse().GetResponseStream(), CompressionMode.Decompress);
    StreamReader objReader = new StreamReader(gzip, Encoding.UTF8);
    string sLine;
    sLine = objReader.ReadToEnd();
    Console.WriteLine(sLine);
