    request = WebRequest.Create(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Location.html") as FileWebRequest;
    public string GetResponse()
            {
                // Get the original response.
                WebResponse response = request.GetResponse();
    
                //this.Status = ((FileWebResponse)response).StatusDescription;
    
                // Get the stream containing all content returned by the requested server.
                dataStream = response.GetResponseStream();
    
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
    
                // Read the content fully up to the end.
                string responseFromServer = reader.ReadToEnd();
    
                // Clean up the streams.
                reader.Close();
                dataStream.Close();
                response.Close();
    
                return responseFromServer;
            }
