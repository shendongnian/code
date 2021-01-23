    public object Get(FStream request)
    {
        var filePath = @"c:\test.xml";
        CompressedResult compressedResult;
        using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        {
            var compressedBtyes = fs.ToUtf8String().Compress(this.RequestContext.CompressionType);
            new CompressedResult(compressedBtyes).WriteTo(Response.OutputStream);           
        }
        Response.EndRequest();
            //  ...cleanup code...
    }
