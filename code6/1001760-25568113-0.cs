             HttpWebRequest httpWebRequest = HttpWebRequest.Create("http://xxx") as HttpWebRequest;
             httpWebRequest.Method = "POST";
             httpWebRequest.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes("user:pw"));
             httpWebRequest.PreAuthenticate = true;
    
             httpWebRequest.SendChunked = true;
             httpWebRequest.AllowWriteStreamBuffering = false;
             httpWebRequest.AllowReadStreamBuffering = false;
             httpWebRequest.ContentType = "application/octet-stream";
             Stream st = httpWebRequest.GetRequestStream();
             Console.WriteLine("Go");
             try
             {
                   st.Write(buffer, 0, buffer.Length); //with the first write, the request will be send.
                   st.Write(buffer, 0, buffer.Length);
                   st.Write(buffer, 0, buffer.Length);
    
                for (int i = 1; i <= 10; i++)
                {
    
                   st.Write(buffer, 0, buffer.Length); //still writing while I can read on the stream at my ASP.NET web api
    
                }
    
                st.Close();
             }
             catch (WebException ex)
             {
                var y = ex.Response;
             }
    
    //now we can read the response from the server (chunked as well)
             Task<WebResponse> response = httpWebRequest.GetResponseAsync();
    
             Stream resultStream = response.Result.GetResponseStream();
    
             byte[] data = new byte[1028];
             int bytesRead;
             while ((bytesRead = resultStream.Read(data, 0, data.Length)) > 0)
             {
                string output = System.Text.Encoding.UTF8.GetString(data, 0, bytesRead);
                Console.WriteLine(output);
             }
