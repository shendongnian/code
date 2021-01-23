    StringBuilder contents = new StringBuilder();
    byte[] content=null;
    string header = "ssoGlobalSessionID=YOUR_SESSION_ID";
    string documentfile = "c:/Users/User/Test.PDF";
    string filename = Path.GetFileName(file);
    static string boundary = Guid.NewGuid().ToString();
    WebRequest request = WebRequest.Create(url);
    request.Method = "POST";
    request.ContentType = string.Format("multipart/form-data; boundary={0}, boundary);
    request.Headers.Add(HttpRequestHeader.Cookie, header);
    AddContentFileCurl(File.ReadAllBytes(documentfile), "documentFile", filename);
    AddContentFormCurl(System.Text.Encoding.ASCII.GetBytes("XMLMARKUP"),"xml");
    LastFileAddedCurl();
    if (content != null)
    {
       request.ContentLength = content.Length;
    }
    Stream dataStream = request.GetRequestStream();
    if (content!=null && content.Length > 0)
    {
       dataStream.Write(content, 0, content.Length);
    }
    dataStream.Close();
    WebResponse response = request.GetResponse();
    dataStream = response.GetResponseStream();
    StreamReader reader = new StreamReader (dataStream);
    string responseReader = reader.ReadToEnd();
    reader.Close();
    dataStream.Close();
    response.Close();
