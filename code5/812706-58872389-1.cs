    public string UploadFilesToRemoteUrl(string url)
        {
            try
            {                             
                Dictionary<string, object> formFields = new Dictionary<string, object>();
                formFields.Add("requestid", "{\"id\":\"idvalue\"}");
                string boundary = "----------------------------" + DateTime.Now.Ticks.ToString("x");
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.ContentType = "multipart/form-data; boundary=" + boundary;
                // basic authentication.
                var username = "userid";
                var password = "password";
                string credidentials = username + ":" + password;
                var authorization = Convert.ToBase64String(Encoding.Default.GetBytes(credidentials));
                request.Headers["Authorization"] = "Basic " + authorization;
                request.Method = "POST";
                request.KeepAlive = true;
                Stream memStream = new System.IO.MemoryStream();
                WriteFormData(formFields, memStream, boundary);
                FileInfo fileToUpload = new FileInfo(@"filelocation with name");
                string fileFormKey = "file";
                if (fileToUpload != null)
                {
                    WritefileToUpload(fileToUpload, memStream, boundary, fileFormKey);
                }
                request.ContentLength = memStream.Length;
                using (Stream requestStream = request.GetRequestStream())
                {
                    memStream.Position = 0;
                    byte[] tempBuffer = new byte[memStream.Length];
                    memStream.Read(tempBuffer, 0, tempBuffer.Length);
                    memStream.Close();
                    requestStream.Write(tempBuffer, 0, tempBuffer.Length);
                }
                using (var response = request.GetResponse())
                {
                    Stream responseSReam = response.GetResponseStream();
                    StreamReader streamReader = new StreamReader(responseSReam);
                    return streamReader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                using (WebResponse response = ex.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response;
                    using (var streamReader = new StreamReader(response.GetResponseStream()))
                        return streamReader.ReadToEnd();
                }
            }
        }
        // write form id.
        public static void WriteFormData(Dictionary<string, object> dictionary, Stream stream, string mimeBoundary)
        {
            string formdataTemplate = "\r\n--" + mimeBoundary +
                                        "\r\nContent-Disposition: form-data; name=\"{0}\";\r\n\r\n{1}";
            if (dictionary != null)
            {
                foreach (string key in dictionary.Keys)
                {
                    string formitem = string.Format(formdataTemplate, key, dictionary[key]);
                    byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
                    stream.Write(formitembytes, 0, formitembytes.Length);
                }
            }
        }
        // write file.
        public static void WritefileToUpload(FileInfo file, Stream stream, string mimeBoundary, string formkey)
        {
            var boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + mimeBoundary + "\r\n");
            var endBoundaryBytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + mimeBoundary + "--");
            string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\n" +
                                    "Content-Type: application/octet-stream\r\n\r\n";
            stream.Write(boundarybytes, 0, boundarybytes.Length);
            var header = string.Format(headerTemplate, formkey, file.Name);
            var headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
            stream.Write(headerbytes, 0, headerbytes.Length);
            using (var fileStream = new FileStream(file.FullName, FileMode.Open, FileAccess.Read))
            {
                var buffer = new byte[1024];
                var bytesRead = 0;
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    stream.Write(buffer, 0, bytesRead);
                }
            }
            stream.Write(endBoundaryBytes, 0, endBoundaryBytes.Length);
        } 
