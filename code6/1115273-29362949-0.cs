    var postData = "grant_type=client_credentials";
    postData += "&param2=value2";
    postData += "&scope=" + HttpUtility.UrlEncode("machinename");
    var data = Encoding.ASCII.GetBytes(postData);
    request.Method = "POST";
    request.ContentType = "application/x-www-form-urlencoded";
    request.ContentLength = data.Length;
    using (var stream = request.GetRequestStream())
    {
        stream.Write(data, 0, data.Length);
    }
    request.ClientCertificates.Add(new System.Security.Cryptography.X509Certificates.X509Certificate(@"E:\MyCertificate.cer"));
    var response = (HttpWebResponse)request.GetResponse();
    var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
    return appToken;
