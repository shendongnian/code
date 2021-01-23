    /// <summary>
    /// Occurs when upload backup application bar button is clicked. Author : Farhan Ghumra
     /// </summary>
    private async void btnUploadBackup_Click(object sender, EventArgs e)
    {
        var dbFile = await ApplicationData.Current.LocalFolder.GetFileAsync(Util.DBNAME);
        var fileBytes = await GetBytesAsync(dbFile);
        var Params = new Dictionary<string, string> { { "userid", "9" } };
        UploadFilesToServer(new Uri(Util.UPLOAD_BACKUP), Params, Path.GetFileName(dbFile.Path), "application/octet-stream", fileBytes);
    }
    
    /// <summary>
    /// Creates HTTP POST request & uploads database to server. Author : Farhan Ghumra
    /// </summary>
    private void UploadFilesToServer(Uri uri, Dictionary<string, string> data, string fileName, string fileContentType, byte[] fileData)
    {
        string boundary = "----------" + DateTime.Now.Ticks.ToString("x");
        HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
        httpWebRequest.ContentType = "multipart/form-data; boundary=" + boundary;
        httpWebRequest.Method = "POST";
        httpWebRequest.BeginGetRequestStream((result) =>
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)result.AsyncState;
                using (Stream requestStream = request.EndGetRequestStream(result))
                {
                    WriteMultipartForm(requestStream, boundary, data, fileName, fileContentType, fileData);
                }
                request.BeginGetResponse(a =>
                {
                    try
                    {
                        var response = request.EndGetResponse(a);
                        var responseStream = response.GetResponseStream();
                        using (var sr = new StreamReader(responseStream))
                        {
                            using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
                            {
                                string responseString = streamReader.ReadToEnd();
                                //responseString is depend upon your web service.
                                if (responseString == "Success")
                                {
                                    MessageBox.Show("Backup stored successfully on server.");
                                }
                                else
                                {
                                    MessageBox.Show("Error occurred while uploading backup on server.");
                                } 
                            }
                        }
                    }
                    catch (Exception)
                    {
    
                    }
                }, null);
            }
            catch (Exception)
            {
    
            }
        }, httpWebRequest);
    }
    
    /// <summary>
    /// Writes multi part HTTP POST request. Author : Farhan Ghumra
    /// </summary>
    private void WriteMultipartForm(Stream s, string boundary, Dictionary<string, string> data, string fileName, string fileContentType, byte[] fileData)
    {
        /// The first boundary
        byte[] boundarybytes = Encoding.UTF8.GetBytes("--" + boundary + "\r\n");
        /// the last boundary.
        byte[] trailer = Encoding.UTF8.GetBytes("\r\n--" + boundary + "--\r\n");
        /// the form data, properly formatted
        string formdataTemplate = "Content-Dis-data; name=\"{0}\"\r\n\r\n{1}";
        /// the form-data file upload, properly formatted
        string fileheaderTemplate = "Content-Dis-data; name=\"{0}\"; filename=\"{1}\";\r\nContent-Type: {2}\r\n\r\n";
    
        /// Added to track if we need a CRLF or not.
        bool bNeedsCRLF = false;
    
        if (data != null)
        {
            foreach (string key in data.Keys)
            {
                /// if we need to drop a CRLF, do that.
                if (bNeedsCRLF)
                    WriteToStream(s, "\r\n");
    
                /// Write the boundary.
                WriteToStream(s, boundarybytes);
    
                /// Write the key.
                WriteToStream(s, string.Format(formdataTemplate, key, data[key]));
                bNeedsCRLF = true;
            }
        }
    
        /// If we don't have keys, we don't need a crlf.
        if (bNeedsCRLF)
            WriteToStream(s, "\r\n");
    
        WriteToStream(s, boundarybytes);
        WriteToStream(s, string.Format(fileheaderTemplate, "file", fileName, fileContentType));
        /// Write the file data to the stream.
        WriteToStream(s, fileData);
        WriteToStream(s, trailer);
    }
    
    /// <summary>
    /// Writes string to stream. Author : Farhan Ghumra
    /// </summary>
    private void WriteToStream(Stream s, string txt)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(txt);
        s.Write(bytes, 0, bytes.Length);
    }
    
    /// <summary>
    /// Writes byte array to stream. Author : Farhan Ghumra
    /// </summary>
    private void WriteToStream(Stream s, byte[] bytes)
    {
        s.Write(bytes, 0, bytes.Length);
    }
    
    /// <summary>
    /// Returns byte array from StorageFile. Author : Farhan Ghumra
    /// </summary>
    private async Task<byte[]> GetBytesAsync(StorageFile file)
    {
        byte[] fileBytes = null;
        using (var stream = await file.OpenReadAsync())
        {
            fileBytes = new byte[stream.Size];
            using (var reader = new DataReader(stream))
            {
                await reader.LoadAsync((uint)stream.Size);
                reader.ReadBytes(fileBytes);
            }
        }
    
        return fileBytes;
    }
