    public static XmlDocument getaddress(string pcode, string number){
        string serverresponse = "";
        string getlocation = "https://ws1.webservices.nl/rpc/get-simplexml/addressReeksPostcodeSearch/efarmatest_User/1d6683d11339c8685cea5132da1af8a1/" + Request.QueryString["PCODE"] + Request.QueryString["NR"];
	
        HttpWebRequest req = (HttpWebRequest) WebRequest.Create(getlocation);
        using (var r = req.GetResponse()) {
            using (var s = new StreamReader(r.GetResponseStream())) {
                serverresponse = s.ReadToEnd();
            }
        }
        
        XmlDocument loader = new XmlDocument();
        loader.LoadXml(serverresponse);
        return loader;
    }
    public static string getvalue(XmlDocument document, string node){
        string returnval = "";
        var results = document.SelectNodes(node);
        foreach(XmlNode aNode in results){
            returnval = returnval + "," + aNode.InnerText;
        }
        return returnval.Substring(1);
    }
