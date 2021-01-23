    using (WebResponse jsonResponse = request.GetResponse())
    {
        // Do something with response
        StreamReader streamReader = new StreamReader(jsonResponse.GetResponseStream());
        String responseData = streamReader.ReadToEnd();
        var myData = JsonConvert.DeserializeObject<List<RootObject>>(responseData);  
        // process your data
        foreach (var rootObject in myData)
        {
            string response = rootObject.response;
            // ...
        }
    }
