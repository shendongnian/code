    // create a list of DTO
    var nameList = new List<NameDTO>();
    
    // loop your data
    foreach (SearchResult sResultSet in search.FindAll())
    {
        // some custom condition
        if (sResultSet.Properties["displayName"].Count > 0)
        {
            // create a DTO object and fill it (i'm not sure about your code)
            var dto = new NameDTO() {
               Id = sResultSet.Properties["mail"][0],
               Name = sResultSet.Properties["displayName"][0]
            }
      
            // add on the list
            nameList.Add(dto); 
        }
    }
    
    // create the serializer object
    JavaScriptSerializer serializer = new JavaScriptSerializer();
    
    // serialize the list of DTO and get the result json
    string output = serializer.Serialize(nameList);
