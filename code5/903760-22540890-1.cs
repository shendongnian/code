    public MyObject CreateQuote(MyObjectRequest myObject)
    {
        var hashtable = new Hashtable
                    {
                        {"myObject", myObject}
                    };
    
        var task = GetResponse("", hashtable);
        var response = task.Result;
    
        MyObject newObject;
        if (response.IsSuccessStatusCode)
        {
    	    // Parse the response body. Blocking!
    	    newObject= response.Content.ReadAsAsync<MyObject>().Result;
        }
    
        return newObject; // instead of response
    } 
