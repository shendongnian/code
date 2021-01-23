     public  string UploadFile(string endpointUrl, string filePath, string accessToken)
        {
            FileStream fs = null;
            Stream rs = null;
            string result = "";
            try
            {
                string uploadFileName = System.IO.Path.GetFileName(filePath);
                
                fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                var request = (HttpWebRequest)WebRequest.Create(endpointUrl);
                request.Method = WebRequestMethods.Http.Post;
                request.AllowWriteStreamBuffering = false;
                request.SendChunked = true;
                String CRLF = "\r\n"; // Line separator required by multipart/form-data.        
                long timestamp = DateTimeOffset.Now.ToUnixTimeSeconds();
                
                string boundary = timestamp.ToString("x");
                request.ContentType = "multipart/form-data; boundary=" + boundary;
         
                request.Headers.Add("Authorization", "Bearer " + accessToken);                             
                               
                long bytesAvailable = fs.Length;
                long maxBufferSize = 1 * 1024 * 1024;
                
                rs = request.GetRequestStream();
                byte[] buffer = new byte[50];
                int read = 0;
                byte[] buf = Encoding.UTF8.GetBytes("--" + boundary + CRLF);
                rs.Write(buf, 0, buf.Length);
                
                buf = Encoding.UTF8.GetBytes("Content-Disposition: form-data; name=\"body\"; filename=\"" + uploadFileName + "\"" + CRLF);                
                rs.Write(buf, 0,buf.Length);
                buf = Encoding.UTF8.GetBytes("Content-Type: application/octet-stream;" + CRLF);
                rs.Write(buf, 0, buf.Length);
                buf = Encoding.UTF8.GetBytes(CRLF);
                //writer.append("Content-Type: application/octet-stream;").append(CRLF);
                rs.Write(buf, 0, buf.Length);
                rs.Flush();
                long bufferSize = Math.Min(bytesAvailable, maxBufferSize);
                buffer = new byte[bufferSize];
                while ((read = fs.Read(buffer, 0, buffer.Length)) != 0)
                {
                    rs.Write(buffer, 0, read);
                }
                buf = Encoding.UTF8.GetBytes(CRLF);                
                rs.Write(buf, 0, buf.Length);
                rs.Flush();
                // End of multipart/form-data.
                buffer = Encoding.UTF8.GetBytes("--" + boundary + "--" + CRLF);
                rs.Write(buffer, 0, buffer.Length);
                using (var response = request.GetResponseWithTimeout())
                using (var responseStream = response.GetResponseStream())
                using (var reader = new StreamReader(responseStream))
                {
                    
                    result = reader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                result = e.InnerException != null ? e.InnerException.Message : e.Message;  
            }
            return result;
        }
