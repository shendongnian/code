    if (!HttpContext.IsPostNotification)
        throw new InvalidOperationException("Only POST messages allowed on this resource");
    
    HttpContext.Request.InputStream.Position = 0;
    
    if (HttpContext.Request.InputStream.Length > int.MaxValue)
        throw new ArgumentException("HTTP InputStream too large.");
    
    int streamLength = Convert.ToInt32(HttpContext.Request.InputStream.Length);
    byte[] byteArray = new byte[streamLength];
    const int startAt = 0;
    
    HttpContext.Request.InputStream.Read(byteArray, startAt, streamLength);
    HttpContext.Request.InputStream.Seek(0, SeekOrigin.Begin);
    
    switch (HttpContext.Request.ContentEncoding.BodyName)
    {
        case "utf-8":
            _postData = Encoding.UTF8.GetString(byteArray);
