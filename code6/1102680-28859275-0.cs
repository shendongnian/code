    string url = baseURLTxtBox.Text;
    
    using(WebClient client = new WebClient())
    {
        System.Collections.Specialized.NameValueCollection nvc = new System.Collections.Specialized.NameValueCollection();
        nvc.Add("ParameterOne", "!@#$%^&*() Anything Any Characters Here");
        nvc.Add("ParameterTwo", LongString);
        byte[] responsebytes = client.UploadValues(url, "POST", nvc);
        string responsebody = Encoding.UTF8.GetString(responsebytes);
    }
