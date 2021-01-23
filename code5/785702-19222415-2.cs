    var a = _client.PostAsync(apiUrl, content).ContinueWith(httpResponseMessage => {
    if (httpResponseMessage.Status!=HttpStatus.OK)
    {
         string ErrorMessage = httpResponseMessage.Result.Content.ReadAsStringAsync();
         //and whatever you want to do with that error message here
    }
    else
    { 
     try
        {
           var user = JsonConvert.DeserializeObject<T>(httpResponseMessage.Result.Content.ReadAsStringAsync().Result);
        }
        catch(Exception ex)
        {
            //honest to goodness unrecoverable failure on the webapi.
            //all you can do here is fail gracefully to the caller.
        }
    }//endif (Status OK)
    }//end anonymous function
    );
