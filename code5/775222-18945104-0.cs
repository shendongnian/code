    var webRequest= (HttpWebRequest)WebRequest.Create(uri);
    webRequest.Method = "POST";
    webRequest.ContentType = "application/json";
    webRequest.ContentLength = jsonData.Length;
    webRequest.BeginGetRequestStream(ar =>
    {
        try
        {
            using (Stream os = webRequest.EndGetRequestStream(ar))
            {
                var postData = Encoding.UTF8.GetBytes(jsonData);
                os.Write(postData, 0, postData.Length);
            }
        }
        catch (Exception ex)
        {
            // Do something, exit out, etc.
        }
        webRequest.BeginGetResponse(
            ar2 =>
            {
                try
                {
                    using (var response = webRequest.EndGetResponse(ar2))
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        string received = reader.ReadToEnd();
                    }
                }
                catch (Exception ex)
                {
                    // Do something, exit out, etc.
                }
            }, null);
    }, null);
