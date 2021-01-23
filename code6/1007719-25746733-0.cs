    //there could be some hash check the scripts via inspect Element
    string postData = String.Format("email={0}&newPassword={1}", "yourusername","yourPassword");
    var request =    (HttpWebRequest)WebRequest.Create("https://secure.systemsecure.com/host/login/23.htm");
    getRequest.Method = WebRequestMethods.Http.Post;
    getRequest.CookieContainer = new CookieContainer();
    getRequest.UserAgent ="Mozilla/5.0 (Windows NT 6.1) AppleWebKit/535.2 (KHTML, like Gecko)Chrome/15.0.874.121 Safari/535.2";
    getRequest.AllowWriteStreamBuffering = true;
    getRequest.ProtocolVersion = HttpVersion.Version10;
    getRequest.AllowAutoRedirect = true;
    getRequest.ContentType = "application/x-www-form-urlencoded";
    byte[] byteArray = Encoding.ASCII.GetBytes(postData);
    getRequest.ContentLength = byteArray.Length;
    Stream newStream = getRequest.GetRequestStream();
    newStream.Write(byteArray, 0, byteArray.Length);
    newStream.Close();
    var getResponse = (HttpWebResponse)getRequest.GetResponse();
