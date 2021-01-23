    WebClient webClient = null;
    XmlReader xmlReader = null;
    try
    {
       webClient = new WebClient();
       webClient.Headers.Add("user-agent", "Mozilla/5.0 (Windows; Windows NT 5.1; rv:1.9.2.4) Gecko/20100611 Firefox/3.6.4");
    
       xmlReader = XmlReader.Create(webClient.OpenRead(url));
    
       // Read XML here because in a finaly block the response stream and the reader will be closed.
    }
    finally
    {
       if (webClient != null)
       { webClient.Dispose(); }
    
       if (xmlReader != null)
       { xmlReader .Dispose(); }
    }
