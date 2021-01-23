    HttpWebRequest request;
    HttpWebResponse response;
    request = (HttpWebRequest)WebRequest.Create(strURL);
    CredentialCache cc = new CredentialCache();
    cc.Add(new Uri(strURL), "Negotiate", (
                (domain == null || domain == "") ?
                new System.Net.NetworkCredential(user, pass) :
                new System.Net.NetworkCredential(user, pass, domain)));
    request.Credentials = cc;
    request.CookieContainer = new CookieContainer();
    response = (HttpWebResponse)request.GetResponse();
