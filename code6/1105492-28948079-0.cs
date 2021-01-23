    static void Main(string[] args)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.xhaus.com/headers");
        request.Method = "POST";
        request.ServicePoint.Expect100Continue = false;
        request.ContentType = "application/x-www-form-urlencoded";
        request.Timeout = 10000;
        request.Headers.Add("Authorization: Bearer_faKE_toKEN_1234");
        string postData = "postData";
        ASCIIEncoding encoding = new ASCIIEncoding();
        byte[] byte1 = encoding.GetBytes(postData);
        request.ContentLength = byte1.Length;
        Stream reqStream = request.GetRequestStream();
        reqStream.Write(byte1, 0, byte1.Length);
        reqStream.Close();
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        Stream dataStream = response.GetResponseStream();
        StreamReader reader = new StreamReader(dataStream);
        string txtResponse = reader.ReadToEnd();
        Console.WriteLine(txtResponse);
        Console.ReadKey();
    }
