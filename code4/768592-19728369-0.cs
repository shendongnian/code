                string serverUrl = "http://www.mywebsite.com/receiveImage.php";
               
                HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(serverUrl);
                webRequest.Method = "POST";
                webRequest.ContentType = "application/x-www-form-urlencoded";
                try
                {
                    IBuffer buffer = await FileIO.ReadBufferAsync(file);
                    byte[] fileData = System.Text.Encoding.UTF8.GetBytes(System.Convert.ToBase64String(buffer.ToArray()).Replace("+","%2B"));
                    byte[] prefix = System.Text.Encoding.UTF8.GetBytes("ImageData=");
                    byte[] combinedData = new byte[fileData.Length + prefix.Length];
                    System.Buffer.BlockCopy(prefix, 0, combinedData, 0, prefix.Length);
                    System.Buffer.BlockCopy(fileData, 0, combinedData, prefix.Length, fileData.Length);
                    Stream requestStream = await webRequest.GetRequestStreamAsync();
                    requestStream.Write(combinedData, 0, combinedData.Length);
                
                
                    // Get the response from the server.
                    WebResponse response = await webRequest.GetResponseAsync();
                    StreamReader requestReader = new StreamReader(response.GetResponseStream());
                    String webResponse = requestReader.ReadToEnd();
                }
                catch (Exception ex)
                {
                }
