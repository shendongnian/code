    var request = (HttpWebRequest)WebRequest.Create(uri);
    // initialization stuff and writing to request stream.
    
    using (var response = (HttpWebResponse)request.GetResponse())
    using (var stream = response.GetResponseStream())
    using (var memoryStream = new MemoryStream())
    {
        // In production this stream is fully received from a remote server.
        stream.CopyTo(memoryStream);
        memoryStream.Seek(0, SeekOrigin.Begin);
    
        // If I run a stopwatch up to this point, I get the round trip time,
        // so I know that the stream has already been received at this point.
        var stopwatch = Stopwatch.StartNew();
    
        var obj = (MyXmlObject)serializer.Deserialize(memoryStream);
    
        stopwatch.Stop();
    }
