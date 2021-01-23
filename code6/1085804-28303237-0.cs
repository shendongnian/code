        string url = "Your Url";
        HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
        request.KeepAlive = false;
        request.ContentType = "application/json";
        request.Method = "POST";
        var entity = new Entity(); //your custom object.
        byte[] bytes = System.Text.Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(entity));
        request.ContentLength = bytes.Length;
        Stream data = request.GetRequestStream();
        data.Write(bytes, 0, bytes.Length);
        data.Close();
        using (WebResponse response = request.GetResponse())
        {
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                string message = reader.ReadToEnd();
                var responseReuslt = JsonConvert.Deserialize<YourDataContract>(message);
            }
        }
