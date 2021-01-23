    public string UploadFilesToRemoteUrl(string url, Dictionary<string, string> files, NameValueCollection nvc, string contenttype)
            {
                string boundary = "----------------------------" +
                DateTime.Now.Ticks.ToString("x");
    
                HttpWebRequest httpWebRequest2 = (HttpWebRequest)GetWebRequest(new Uri(url)); //(HttpWebRequest)WebRequest.Create(url);
                SetProxy(httpWebRequest2);
                SetUserAgent(httpWebRequest2);
                httpWebRequest2.ContentType = "multipart/form-data; boundary=" + boundary;
                httpWebRequest2.Timeout = WebRequestTimeout; // 60 second * miliseconds * 60 minutes = 1 hour
                httpWebRequest2.Method = "POST";
                httpWebRequest2.KeepAlive = true;
                httpWebRequest2.Credentials =
                System.Net.CredentialCache.DefaultCredentials;
    
                Stream memStream = new System.IO.MemoryStream();
                byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");
    
                string formdataTemplate = "\r\n--" + boundary + "\r\nContent-Disposition: form-data; name=\"{0}\";\r\n\r\n{1}";
    
                if (nvc != null)
                {
                    foreach (string key in nvc.Keys)
                    {
                        string formitem = string.Format(formdataTemplate, key, nvc[key]);
                        byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
                        memStream.Write(formitembytes, 0, formitembytes.Length);
                    }
                }
    
                memStream.Write(boundarybytes, 0, boundarybytes.Length);
    
                string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\n\r\n";
                if (string.IsNullOrEmpty(contenttype) == false)
                {
                    headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\n" + contenttype + "\r\n";
                }
    
                string[] keys = nvc.AllKeys;
                foreach (KeyValuePair<string, string> key in files)
                {
                    //string header = string.Format(headerTemplate, "file" + i, files[i]);
                    //string header = string.Format(headerTemplate, "uplTheFile", files[i]);
                    string header = string.Format(headerTemplate, key.Key, key.Value);
                    byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
    
                    memStream.Write(headerbytes, 0, headerbytes.Length);
    
                    FileStream fileStream = new FileStream(key.Value, FileMode.Open, FileAccess.Read);
                    byte[] buffer = new byte[buffsize];
    
                    int bytesRead = 0;
    
                    while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        memStream.Write(buffer, 0, bytesRead);
                        int progress = Convert.ToInt32((memStream.Length * 100) / fileStream.Length);
                        ReportProgress(key.Value, progress);
                    }
    
                    memStream.Write(boundarybytes, 0, boundarybytes.Length);
                    fileStream.Close();
                    if (MonitoredDownload != null) MonitoredDownload.OnComplete(key.Value);
                    buffer = null;
                    headerbytes = null;
                }
    
                httpWebRequest2.ContentLength = memStream.Length;
    
                Stream requestStream = httpWebRequest2.GetRequestStream();
                memStream.Position = 0;
                byte[] tempBuffer = new byte[buffsize];
                int bytereads = 0;
                while ((bytereads = memStream.Read(tempBuffer, 0, tempBuffer.Length)) != 0)
                {
                    requestStream.Write(tempBuffer, 0, bytereads);
                }
    
                //memStream.Read(tempBuffer, 0, tempBuffer.Length);
                memStream.Close();
                memStream.Dispose();
                //requestStream.Write(tempBuffer, 0, tempBuffer.Length);
                requestStream.Close();
                requestStream.Dispose();
    
                WebResponse webResponse2 = httpWebRequest2.GetResponse();
                //SaveCookie(webResponse2, new Uri(url).GetLeftPart(UriPartial.Authority));
                Stream stream2 = webResponse2.GetResponseStream();
                StreamReader reader2 = new StreamReader(stream2);
                string str = reader2.ReadToEnd();
                reader2.Close();
                reader2.Dispose();
    
                stream2.Close();
                stream2.Dispose();
                webResponse2.Close();
    
                httpWebRequest2 = null;
                webResponse2 = null;
                tempBuffer = null;
                return str;
            }
