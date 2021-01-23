    string sb = "";
    List<string> listGamme = new List<string>();
    sb = ("<?xml....") ;//1st listGamme
    listGamme.Add(sb);
    sb = ("<?xml..."); //2nd listGamme
    listGamme.Add(sb);
    foreach (string gamme in listGamme)
                            {
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create("urlofmy.asmx");
        req.Headers.Add("SOAPAction", "URLSOAPACTION");
        req.ContentType = "text/xml;charset=\"utf-8\"";
        req.Accept = "text/xml";
        req.Method = "POST";
                using (Stream stm = req.GetRequestStream())
                {
                    using (StreamWriter stmw = new StreamWriter(stm))
                    {
                         
                                 stmw.Write(gamme); 
                     }
                }
        WebResponse response = req.GetResponse();
        StreamReader srreader = new StreamReader(response.GetResponseStream());
    }
