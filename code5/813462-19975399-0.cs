      using System.IO;
      using System.Net;
      using System.Text;
      
      // ...
    
      var request = WebRequest.Create("http://localhost:54903/SimpleLogin.ashx") as HttpWebRequest;
      var container = new CookieContainer();
      request.CookieContainer = container;
      string postData = "username=user&password=pass";
      byte[] data = Encoding.ASCII.GetBytes(postData);
      request.Method = "POST";
      request.ContentType = "application/x-www-form-urlencoded";
      request.ContentLength = data.Length;
      using (var stream = request.GetRequestStream()) {
        stream.Write(data, 0, data.Length);
      }
      var response = (HttpWebResponse)request.GetResponse();
      request = WebRequest.Create("http://localhost:54903/Home.ashx") as HttpWebRequest;
      request.CookieContainer = container;
      request.Method = "GET";
      response = (HttpWebResponse)request.GetResponse();
      string authorizedGetString;
      using (var stream = response.GetResponseStream()) {
        using (var streamReader = new StreamReader(stream)) {
          authorizedGetString = streamReader.ReadToEnd();
        }
      }
