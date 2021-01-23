     string sURL = "http://api.planets.nu/games/list?limit=1";
     HttpWebRequest wrGetURL = (HttpWebRequest)WebRequest.Create(sURL);
     wrGetURL.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
     StreamReader objReader = new StreamReader(wrGetURL.GetResponse().GetResponseStream(), Encoding.UTF8);
     string sLine;
     sLine = objReader.ReadToEnd();
     Console.WriteLine(sLine);
