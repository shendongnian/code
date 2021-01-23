                string requestUri = Path.Combine(serverIP + @"/upload/", filename);
                HttpWebRequest client = (HttpWebRequest)WebRequest.Create(requestUri);
                client.Method = WebRequestMethods.Http.Post;
                
                client.AllowWriteStreamBuffering = true;
                client.SendChunked = true;
                client.ContentType = "multipart/form-data;";
                client.Timeout = int.MaxValue;
                using (FileStream fileStream = File.OpenRead(filePath))
                {
                    fileStream.Copy(client.GetRequestStream());
                }
                var response = new StreamReader(client.GetResponse().GetResponseStream()).ReadToEnd();
       
