    using (WebResponse jsonResponse = request.GetResponse())
    {
        // Do something with response
        StreamReader streamReader = new StreamReader(jsonResponse.GetResponseStream());
        String responseData = streamReader.ReadToEnd();
    	RootObject myData = JsonConvert.DeserializeObject<RootObject>(responseData);  
    	// process your data
    }
