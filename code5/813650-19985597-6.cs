    static void Main(string[] args)
    {
        ASCIIEncoding encoding = new ASCIIEncoding();
        string SampleXml = "<DataRequest xmlns=\"YourNamespaceHere\">" +
                                        "<ID>" +
                                        yourIDVariable +
                                        "</ID>" +
                                        "<Data>" +
                                        yourDataVariable +
                                        "</Data>" +
                                    "</DataRequest>";
    
        string postData = SampleXml.ToString();
        byte[] data = encoding.GetBytes(postData);
    
        string url = "http://localhost:62810/MyService.svc/GetData";
    
        string strResult = string.Empty;
    
        // declare httpwebrequet wrt url defined above
        HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
        // set method as post
        webrequest.Method = "POST";
        // set content type
        webrequest.ContentType = "application/xml";
        // set content length
        webrequest.ContentLength = data.Length;
        // get stream data out of webrequest object
        Stream newStream = webrequest.GetRequestStream();
        newStream.Write(data, 0, data.Length);
        newStream.Close();
    
        //Gets the response
        WebResponse response = webrequest.GetResponse();
        //Writes the Response
        Stream responseStream = response.GetResponseStream();
    
        StreamReader sr = new StreamReader(responseStream);
        string s = sr.ReadToEnd();
    
        return s;
    }
