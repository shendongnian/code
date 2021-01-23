    You can update your `GetAllUpdate` method something like this
    
    public string GetAllUpdates(){
              try{
                  var result = GetCountries();
    
                  if(string.isNullOrEmpty(result)
                   return result;
      
    
                  result  = GetAreas();
    
                  if(string.isNullOrEmpty(result)
                   return result;
    
                  result  = GetCities();
    
                  if(string.isNullOrEmpty(result)
                   return result;
    
                  ...
       
                  result = "All updated successfully";
    
                  return result;
    
              }
              catch (TimeoutException ex)
              {
                   Log.Error("Web Service Timeout", ex);
                   return "Failed to contact web services.";
              }
              catch (Exception ex)
              {
                   Log.Error("Exception", ex);
                   return "An error has occurred.";
              }
         }
