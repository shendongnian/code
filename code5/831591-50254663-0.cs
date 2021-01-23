    string fileName = null;
    
    // Getting file name
    var request = WebRequest.Create(url);
    request.Method = "HEAD";
    
    using (var response = request.GetResponse())
    {
        // Headers are not correct... So we need to parse manually
        var contentDisposition = response.Headers["Content-Disposition"];
        
        // We delete everything up to and including 'Filename="'
        var fileNameMarker= "filename=\"";
        var beginIndex = contentDisposition.ToLower().IndexOf(fileNameMarker);
        contentDisposition = contentDisposition.Substring(beginIndex + fileNameMarker.Length);
        
        //We only get the string until the next double quote
        var fileNameLength = contentDisposition.ToLower().IndexOf("\"");
        fileName = contentDisposition.Substring(0, fileNameLength);
    }
