    using (WebResponse response = request.GetResponse())
    {
        using (Stream streamResponse = response.GetResponseStream())
        {
            StringBuilder sb = new StringBuilder();
    
            if (streamResponse != null)
            {
                using (StreamReader readStream = new StreamReader(streamResponse, Encoding.UTF8))
                {
                    sb.Append(readStream.ReadToEnd());
                }
            }
        }
     }
