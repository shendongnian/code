    var writer = XmlWriter.Create(
        new FileStream("api.xml",
                        FileMode.Create));
    writer.WriteStartElement("apps"); // root element in the xml
    // lock for one write
    object writeLock = new object(); 
    // this many calls            
    int counter = appList.Count;
    
    foreach (var app in appList)
    {
        var wc = new WebClient();
                
        var url = String.Format(
            "http://example.com/getapplist.do?appid={0}&bldid=Bld2", 
            app);
        wc.DownloadDataCompleted += (o, args) =>
            {
                try
                {
                    var xd = new XmlDocument();
                    xd.LoadXml(Encoding.UTF8.GetString(args.Result));
                    lock (writeLock)
                    {
                        xd.WriteContentTo(writer);
                    }
                }
                finally
                {
                    // count down our counter in a thread safe manner
                    if (Interlocked.Decrement(ref counter) == 0)
                    {
                        // this was the last one, close nicely
                        writer.WriteEndElement();
                        writer.Close();
                        ((IDisposable) writer).Dispose();
                    }
                }
            };
        wc.DownloadDataAsync(
            new Uri(url));   
    }
