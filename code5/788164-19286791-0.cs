    var request = (HttpWebRequest)WebRequest.Create(url);
    request.Method = "POST";
    request.ContentType = "application/x-www-form-urlencoded";
    // Every so often I've seen weird issues if the user agent isn't set
    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
    
    // encode the data for transmission
    byte[] bytedata = Encoding.UTF8.GetBytes(parameters.ToString());
    
    // tell the other side how much data is coming
    request.ContentLength = bytedata.Length; 
    
    using (var writer = new StreamWriter(request.GetRequestStream()))
    {
    	writer.Write(bytedata, 0, bytedata.Length);
    }
    String result = String.Empty;
    
    using (var response = (HttpWebResponse)request.GetResponse()) {
    	using(StreamReader reader = new StreamReader(response.GetResponseStream())) {
    		result = reader.ReadToEnd(); // gets the response from the server
    		// output this or at least look at it.
    		// generally you want to send a success or failure message back.
    	}
    }
    
    // not sure why you were returning the request object.
    // you really just want to pass the result back from your method
    return result; 
