		HttpWebRequest req = null;
        HttpWebResponse rsp = null;
        string fileName = @"c:\Test.xml";
        string uri = "your second application URL with Page, where you want to get the XML Data";
        req = (HttpWebRequest)HttpWebRequest.Create(uri);
        // req.Proxy = WebProxy.GetDefaultProxy(); // Enable if using proxy
        req.Method = "POST"; // Post method
        req.ContentType = "text/xml"; // content type
        // Wrap the request stream with a text-based writer
        StreamWriter writer = new StreamWriter(req.GetRequestStream());
        // Write the XML text into the stream
        writer.WriteLine(GetTextFromXMLFile(fileName));
        writer.Close();
        // Send the data to the webserver
        rsp = (HttpWebResponse)req.GetResponse();
        Stream Answer = rsp.GetResponseStream();
         //_Answer = new StreamReader(Answer);
        XmlTextReader _Answer = new XmlTextReader(Answer); 
