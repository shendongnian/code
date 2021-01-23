    public void Test() {
    string xmlMessage =  "<ENVELOPE>
    <HEADER>
    <VERSION>1</VERSION>
    <REQVERSION>1</REQVERSION>
    <TALLYREQUEST>EXPORT</TALLYREQUEST>
    <TYPE>DATA</TYPE>
    <ID>TPGETCOMPANIES</ID>
    <SESSIONID>" .$session. "</SESSIONID>
    <TOKEN>" .$token. "</TOKEN>
    </HEADER>
    <BODY>
    <DESC>
    <STATICVARIABLES>
        <SVINCLUDE>CONNECTED</SVINCLUDE>
    </STATICVARIABLES>
    </DESC>
    </BODY>
    </ENVELOPE>";
    //Sending the request to Tally test URL address
    string url = "www.xxxxxxx.com";
    
    //create a request
    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
    request.KeepAlive = false;
    request.ProtocolVersion = HttpVersion.Version10;
    request.Method = "POST";
    string postData = xmlMessage;
    
    byte[] byteArray = Encoding.UTF8.GetBytes(postData);
    
    request.ContentType = "text/xml;charset=utf-8";
    request.ContentLength = byteArray.Length;
    
    request.Headers.Add("ID", "TPGETCOMPANIES");
    request.Headers.Add("SOURCE", "EA");
    request.Headers.Add("TARGET", "TNS");
    request.Headers.Add("CONTENT-TYPE", "text/xml;charset=utf-8");
    
    Stream requestStream = request.GetRequestStream();  
    requestStream.Write(byteArray, 0, byteArray.Length);
    requestStream.Close();
    
    HttpWebResponse response = (HttpWebResponse)request.GetResponse();   
    StreamReader respStream = new StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8);
    
    string receivedResponse = respStream.ReadToEnd();
    Label2.Text = receivedResponse;
    
    respStream.Close();
    response.Close();
    }
