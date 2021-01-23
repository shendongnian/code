    using (var response = (HttpWebResponse)request.GetResponse()){
    	var responseValue = string.Empty;
    
    	// Error
    	if (response.StatusCode != HttpStatusCode.OK){
    		var message = String.Format("Request failed. Received HTTP {0}", response.StatusCode);
    		throw new ApplicationException(message);
    	}
    
    	// Grab the response
    	using (var responseStream = response.GetResponseStream()){
    		if (responseStream != null){
    			using (var reader = new StreamReader(responseStream)){
    				responseValue = reader.ReadToEnd();
    			}
    		}
    	}
    }
