    void context_CompressResponse(object sender, EventArgs e)
    {
        HttpApplication app = (HttpApplication)sender;
        string encodings = app.Request.Headers.Get(ACCEPT_ENCODING);
        if (encodings == null)
        {
            return;
        }
        encodings = encodings.ToLower();
        if (encodings.Contains(GZIP))
        {
            Stream baseStream = app.Response.Filter;
            //1
            app.Response.Filter = new GZipStream(baseStream, CompressionMode.Compress);
            //2
            app.Response.AppendHeader(CONTENT_ENCODING, GZIP);
        }
        Response.Cache.VaryByHeaders[ACCEPT_ENCODING] = true;
    }
