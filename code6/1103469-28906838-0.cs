    private byte[] GetURLContents(string url)
    {
        // The downloaded resource ends up in the variable named content. 
        var content = new MemoryStream();
    
        // Initialize an HttpWebRequest for the current URL. 
        var webReq = (HttpWebRequest)WebRequest.Create(url);
    
        // Send the request to the Internet resource and wait for 
        // the response. 
        // Note: you can't use HttpWebRequest.GetResponse in a Windows Store app. 
        using (WebResponse response = webReq.GetResponse())
        {
            // Get the data stream that is associated with the specified URL. 
            using (Stream responseStream = response.GetResponseStream())
            {
                // Read the bytes in responseStream and copy them to content.  
                responseStream.CopyTo(content);
            }
        }
    
        // Return the result as a byte array. 
        return content.ToArray();
    }
