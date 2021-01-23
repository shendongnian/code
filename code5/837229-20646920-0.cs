    public void UploadImage(byte[] content)
    {
        string boundary = Guid.NewGuid().ToString();
        string header = string.Format("--{0}", boundary);
        string footer = string.Format("--{0}--", boundary);
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.imgur.com/3/upload");
        request.Method = "POST";
        request.Headers["Authorization"] = "Client-ID " + clientID;
        request.ContentType = "multipart/form-data, boundary=" + boundary;
        StringBuilder builder = new StringBuilder();
        string base64string = Convert.ToBase64String(content);
        builder.AppendLine(header);
        builder.AppendLine("Content-Disposition: form-data; name=\"image\"");
        builder.AppendLine();
        builder.AppendLine(base64string);
        builder.AppendLine(footer);
        byte[] data = Encoding.UTF8.GetBytes(builder.ToString());
        using (Stream s = request.GetRequestStream())
        {
            s.Write(data, 0, data.Length);
        }
        try
        {
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                var imageURL = reader.ReadToEnd();
                Regex regex = new Regex(@"https?://([-\w\.]+)+(:\d+)?(/([-\w/_\.]*(\?\S+)?)?)?");
                MatchCollection matches = regex.Matches(imageURL);
                foreach (Match match in matches)
                {
                    finalImageURL = match.Value;
                }
            }
        }
        catch (WebException ex)
        {
            using (StreamReader reader = new StreamReader(ex.Response.GetResponseStream()))
            {
                imageURL = "An uploading error occured. Please check your connection.";
            }
        }
    }
