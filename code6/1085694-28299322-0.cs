     public string GetAllUpdates()
     {
          try
          {
              GetCountries();
              try 
              {
                  GetAreas();
                  // ... and so on
              }
              catch(Exception ex)
              {
                  return "Error getting areas";
              }
          }
          catch(Exception ex) 
          {
              return "Error getting countries";
          }
  
