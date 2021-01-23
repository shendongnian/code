    var request = (HttpWebRequest)WebRequest.Create(url);
    request.Method = "GET";
    string content;
    HttpStatusCode statusCode;
    using (var response = request.GetResponse())
    using (var stream = response.GetResponseStream())
    {
        var contentType = response.ContentType;
        Encoding encoding = null;
        if (contentType != null)
        {
            var match = Regex.Match(contentType, @"(?<=charset\=).*");
            if (match.Success)
                encoding = Encoding.GetEncoding(match.ToString());
        }
        encoding = encoding ?? Encoding.UTF8;
        statusCode = ((HttpWebResponse)response).StatusCode;
        using (var reader = new StreamReader(stream, encoding))
            content = reader.ReadToEnd();
    }
