    CookieContainer container = new CookieContainer();
    CookieCollection cookies = new CookieCollection();
    
    for (var i = 0; i < Listchat.Length; i++)
    {
        string url = Listchat[i] + "/ajax/";
        string par = "act=login&chat=" + "4952" + "&msg=" + log + "&pass=" + pass + "&remember=0&pv=0&c=&bind=0";
    
        HttpWebRequest request3 = (HttpWebRequest)WebRequest.Create(url);
        request3.CookieContainer = container;
        request3.CookieContainer.Add(cookies);
        request3.UserAgent = "Opera/9.80";
        request3.Method = "POST";
        request3.ContentType = "application/x-www-form-urlencoded";
        byte[] EncodedPostParams3 = Encoding.Default.GetBytes(par);
        request3.ContentLength = EncodedPostParams3.Length;
        request3.GetRequestStream().Write(EncodedPostParams3, 0, EncodedPostParams3.Length);
        request3.GetRequestStream().Close();
        request3.AllowAutoRedirect = false;
        HttpWebResponse response = (HttpWebResponse)request3.GetResponse();
        cookies = response.Cookies;
    
    
        //SEND MESSAGE!!   Here the message is sent to the chat only 1 time and lost authorization
    
    
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(Listchat[i] + "/ajax/?act=send&chat=" +"4952" + "&channel=main&pv=0&msg=" + mess + "");
        req.CookieContainer = container;
        req.CookieContainer.Add(cookies);
        req.Timeout = 20 * 60 * 1000;
        req.KeepAlive = true;
        HttpWebResponse respons = (HttpWebResponse)req.GetResponse();
        cookies = respons.Cookies;
        Stream dataStream = respons.GetResponseStream();
        StreamReader reader = new StreamReader(dataStream);
        string responseFromServer = reader.ReadToEnd();
        reader.Close();
        dataStream.Close();
        respons.Close();
        label2.Text = responseFromServer;
    }
