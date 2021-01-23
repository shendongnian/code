    using (var stream = File.Open (@"C:\temp\test.txt", FileMode.Open))
    {
        // note: StreamContent has no Content-Type set by default
        // set a suitable Content-Type for ReadAsMultipartAsync()
        var content = new StreamContent (stream) ;
        content.Headers.ContentType = 
            System.Net.Http.Headers.MediaTypeHeaderValue.Parse (
                "multipart/related; boundary=cbsms-main-boundary") ;
        // TODO: make this recursive if required...
        var outerMultipart = await stream.ReadAsMultipartAsync () ;
        foreach (var outerPart in outerMultipart.Contents)
        {
            if (outerPart.IsMimeMultipartContent())
            {
                var innerMultipart = await outerPart.ReadAsMultipartAsync () ;
                foreach (var innerPart in innerMultipart.Contents) // do stuff
            }
            else // do other stuff
        }
    }
