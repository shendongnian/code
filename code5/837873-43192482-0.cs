    HttpClient client = //...
    // Must use ResponseHeadersRead to avoid buffering of the content
    using (var response = await client.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead)){
        // You must use as stream to have control over buffering and number of bytes read/received
        using (var stream = await response.Content.ReadAsStreamAsync())
        {
            // Read/process bytes from stream as appropriate
            // Calculated by you based on how many bytes you have read.  Likely incremented within a loop.
            long bytesRecieved = //...
            long? totalBytes = response.Content.Headers.ContentLength;
            double? percentComplete = (double)bytesRecieved / totalBytes;
	        // Do what you want with `percentComplete`
        }
    }
