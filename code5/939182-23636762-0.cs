        WebHeaderCollection headers;
        using (var cl = new WebClient())
        {
            headers = cl.ResponseHeaders;
        }
        // headers is still in scope
        foreach (var k in headers.AllKeys) 
            Debug.WriteLine("{0} : {1}", k, headers[k]);
