    // this instance will be reused across multiple requests
    private static CookieContainer cookieContainer = new CookieContainer();
    public static string Post(string RequestName, string PostData, out HttpStatusCode ReturnCode)
    {
        byte[] byteArray = Encoding.UTF8.GetBytes(PostData);
        WebRequest Request = WebRequest.Create(ChatAPI.Settings.BaseUrl + RequestName);
        Request.Method = "POST";
        Request.ContentType = "application/x-www-form-urlencoded";
        Request.ContentLength = byteArray.Length;
        Request.CookieContainer = cookieContainer; // this line is new
        Stream dataStream = Request.GetRequestStream();
        dataStream.Write(byteArray, 0, byteArray.Length);
        dataStream.Close();
        WebResponse response = Request.GetResponse();
        dataStream = response.GetResponseStream();
        ReturnCode = ((HttpWebResponse)response).StatusCode;
        StreamReader reader = new StreamReader(dataStream);
        string returnedData = reader.ReadToEnd();
        reader.Close();
        dataStream.Close();
        response.Close();
        return returnedData;
    }
