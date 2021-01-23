    int userid = 1;
    
    string xmlString = string.Format("~/XMLHandler.ashx?userId={0}", userid);
    WebRequest req = WebRequest.Create(Server.MapPath("~\")+xmlString);
    req.Proxy = null;
    req.Method = "POST";
    string responseFromServer="";
     try
    {
    WebResponse response = req.GetResponse();
    Stream dataStream = response.GetResponseStream();
    var statusCode = ((HttpWebResponse)response).StatusCode;
    
    StreamReader reader = new StreamReader(dataStream);
    responseFromServer = reader.ReadToEnd();
    
    using(System.IO.StreamWriter file = new System.IO.StreamWriter("e:\\vypujcky.xml"))
    {
    file.WriteLine(responseFromServer);
    }
                        
    }
    catch (WebException ex)
    {
    
                     
    }
