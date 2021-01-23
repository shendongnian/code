    //Get the key/value connection string from app config  
    var sect = (NameValueCollection)ConfigurationManager.GetSection("section");  
    var val = sect["New DataSource"].ToString();
    //Get the original connection string with the full payload  
    var entityCnxStringBuilder = new EntityConnectionStringBuilder(ConfigurationManager.ConnectionStrings["OriginalStringBuiltByADO.Net"].ConnectionString);     
    //Swap out the provider specific connection string  
    entityCnxStringBuilder.ProviderConnectionString = val;
    //Return the payload with the change in connection string.   
    return entityCnxStringBuilder.ConnectionString;
