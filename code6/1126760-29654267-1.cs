    var update = new update();
    update.name = "Test Name";
        
    var httpWebRequest = HttpWebRequest.Create ("api.example.com/profiles/1") as HttpWebRequest;
    
    httpWebRequest.Method = "PATCH";
    httpWebRequest.ContentType = "text/json";
    httpWebRequest.Timeout = 5000;
    
    using (var streamWriter = new StreamWriter (httpWebRequest.GetRequestStream ())) {
    	streamWriter.Write (JsonConvert.SerializeObject(update));
    }
    
    using (WebResponse response = httpWebRequest.GetResponse ()) {
    	streamReader = new StreamReader (response.GetResponseStream ());
    	var objectResponse = JsonConvert.DeserializeObject<your_object> (streamReader.ReadToEnd ());
    }
