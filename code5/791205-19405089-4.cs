    try
    {
    	IEnumerable<string> registrationdIds = new List<string>(){"reg1","reg2","reg3"....,"reg1000"};
    	var webRequest = WebRequest.Create("GCMServerUrl");
    	webRequest.Headers.Add(HttpRequestHeader.Authorization, string.Format("Key={0}", "GCMApiKey"));
    	webRequest.ContentType = "application/json";
    	webRequest.Method = "POST";
    	var requestStream = webRequest.GetRequestStream();
    
    	var message = new Dictionary<string, object>();
    	var data = new Dictionary<string, object>();
    	var parameters = new NameValueCollection();
    
    	var registrationIds = UserManagement.GetDefaultUserManagement().GetUserAndroidRegistrationIds();
    	message.Add("registration_ids", registrationIds);
    	data.Add("Field1", "This is Field1");
    	data.Add("Field2", "This is Field2");
    	message.Add("data", data);
    
    	var jsonString = JsonConvert.SerializeObject(message);
    
    	byte[] buffer = Encoding.UTF8.GetBytes(jsonString);
    	requestStream.Write(buffer, 0, buffer.Length);
    
    	using (var response = webRequest.GetResponse())
        {
    	    Logger.DebugFormat("Sent a GCM message. Response was:{0}", response);
        }
    }
    catch (Exception ex)
    {
    	Logger.ErrorFormat("Error occurred while sending GCM notification. Ex: {0}", ex);
    }
