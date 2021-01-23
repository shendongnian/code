    var request            = (HttpWebRequest)WebRequest.Create(Url);
    byte[] byteArray       = Encoding.UTF8.GetBytes(YourParametersString);
    
    request.Method         = WebRequestMethods.Http.Post;
    request.ContentLength  = byteArray.Length;
    request.ContentType    = "application/json";
    
    Stream postStream      = request.GetRequestStream();
    postStream.Write(byteArray, 0, byteArray.Length);
    postStream.Close();
