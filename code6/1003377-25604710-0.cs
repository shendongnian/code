     //For saving in cache
         WebCache.Set("test", "any data comes here", 10, false); // Cache the value for 10 minutes
        
        //Retrieving the data
            string test = WebCache.Get("test");
            if(!string.IsNullOrEmpty(test))
            {
             //get test value here
            }
            else
            {
              //No data msg
            }
