    var webAddr = "http://localhost:22678/api/Account/Login";
    var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
    httpWebRequest.ContentType = "application/json; charset=utf-8";
    httpWebRequest.Method = "POST";
    
    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
    {
          var loginBindingModel = new WebAPILoginBindingModel { Password = "test01", UserName = "test01" };
          var myJsonString = Newtonsoft.Json.JsonConvert.SerializeObject(loginBindingModel);
                        streamWriter.Write(myJsonString);
                        streamWriter.Flush();
    }
    
    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
    {
        var result = streamReader.ReadToEnd();
    }
