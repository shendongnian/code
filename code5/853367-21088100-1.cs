    using System.Net;
    using System.Collections.Specialized;
    using (var client = new WebClient())
    {
        var values = new NameValueCollection();
        values["username"] = "user1";
        values["password"] = "12345";
    
        var response = client.UploadValues("https://www.mydomain.com/login.aspx", values);
    
        var responseString = Encoding.Default.GetString(response);
    }
