    long UploadFile(string path, string url, string contentType)
    {
        // Build request
        var request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = WebRequestMethods.Http.Post;
        request.AllowWriteStreamBuffering = false;
        request.ContentType = contentType;
        string fileName = Path.GetFileName(path);
        request.Headers["Content-Disposition"] = string.Format("attachment; filename=\"{0}\"", fileName);
         
        try
        {
            // Open source file
            using (var fileStream = File.OpenRead(path))
            {
                // Set content length based on source file length
                request.ContentLength = fileStream.Length;
                 
                // Get the request stream with the default timeout
                using (var requestStream = request.GetRequestStreamWithTimeout())
                {
                    // Upload the file with no timeout
                    fileStream.CopyTo(requestStream);
                }
            }
             
            // Get response with the default timeout, and parse the response body
            using (var response = request.GetResponseWithTimeout())
            using (var responseStream = response.GetResponseStream())
            using (var reader = new StreamReader(responseStream))
            {
                string json = reader.ReadToEnd();
                var j = JObject.Parse(json);
                return j.Value<long>("Id");
            }
        }
        catch (WebException ex)
        {
            if (ex.Status == WebExceptionStatus.Timeout)
            {
                LogError(ex, "Timeout while uploading '{0}'", fileName);
            }
            else
            {
                LogError(ex, "Error while uploading '{0}'", fileName);
            }
            throw;
        }
    }
