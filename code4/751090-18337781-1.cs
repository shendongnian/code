    /// <summary>
    ///     Send a File with initialized request.
    /// </summary>
    private void GetRequestStreamCallback(IAsyncResult asynchronousResult)
    {
        string contentType = "binary";
        string myFileContent = "one;two;three;four;five;"; // CSV content.
        HttpWebRequest request = (HttpWebRequest)asynchronousResult.AsyncState;
        Stream memStream = request.EndGetRequestStream(asynchronousResult);
        byte[] boundarybytes = System.Text.Encoding.UTF8.GetBytes("\r\n--" + Boundary + "\r\n");
        memStream.Write(boundarybytes, 0, boundarybytes.Length);
        // Send headers.
        string headerTemplate = "Content-Disposition: form-data; ";
        headerTemplate += "name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: " + contentType + "\r\n\r\n";
        string fileName = "MyFileName.csv";
        string header = string.Format(headerTemplate, "file", fileName);
        byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
        memStream.Write(headerbytes, 0, headerbytes.Length);
        byte[] contentbytes = System.Text.Encoding.UTF8.GetBytes(myFileContent);
            
        // send the content of the file.
        memStream.Write(contentbytes, 0, contentbytes.Length);
        // Send last boudary of the file ( the footer) for specify post request is finish.
        byte[] boundarybytesend = System.Text.Encoding.UTF8.GetBytes("\r\n--" + Boundary + "--\r\n");
        memStream.Write(boundarybytesend, 0, boundarybytesend.Length);
        memStream.Flush();
        memStream.Close();
        allDone.Set();
        // Start the asynchronous operation to get the response
        request.BeginGetResponse(new AsyncCallback(GetResponseCallback), request);
    }
