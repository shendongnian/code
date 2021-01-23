    private static WebServerRequestData SendResponse(HttpListenerRequest request)
        {
            string dir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string[] fileUrl = request.RawUrl.Split('/');
            // routes
            if (request.RawUrl.Contains("/"))
            {
                // this is the main page ('/'), all other routes can be accessed from here (including css, js, & images)
                if (request.RawUrl.ToLower().Contains(".png") || request.RawUrl.ToLower().Contains(".ico") || request.RawUrl.ToLower().Contains(".jpg") || request.RawUrl.ToLower().Contains(".jpeg"))
                {
                    try
                    {
                        string path = dir + Properties.Settings.Default.ImagesPath + fileUrl[fileUrl.Length - 1];
                        FileInfo fileInfo = new FileInfo(path);
                        path = dir + @"\public\imgs\" + fileInfo.Name;
                        
                        byte[] output = File.ReadAllBytes(path);
                        _data = new WebServerRequestData() {Content = output, ContentType = "image/png", RawUrl = request.RawUrl};
                        //var temp = System.Text.Encoding.UTF8.GetString(output);
                        //return Convert.ToBase64String(output);
                        return _data;
                    }
                    catch(Exception ex)
                    {
                        ConfigLogger.Instance.LogError(LogCategory, "File could not be read.");
                        ConfigLogger.Instance.LogCritical(LogCategory, ex);
                        _errorString = string.Format("<html><head><title>Test</title></head><body>There was an error processing your request:<br />{0}</body></html>", ex.Message);
                        _byteData = new byte[_errorString.Length * sizeof(char)];
                        System.Buffer.BlockCopy(_errorString.ToCharArray(), 0, _byteData, 0, _byteData.Length);
                        _data = new WebServerRequestData() { Content = _byteData, ContentType = "text/html", RawUrl = request.RawUrl };
                        return _data;
                    }
                }
