    public List<string> GetPropertiesNameOfClass(UserModel olduser, UserModel newuser)
    {
        var propertyNameList = new List<string>();
        var propertyOldValue = new List<object>();
        var propertyNewValue = new List<object>();
                
        foreach (var prop in olduser.GetType().GetProperties())
        {
    
            propertyNameList.Add(prop.Name);
    
            propertyOldValue.Add(prop.GetValue(olduser, null));
    
        }
    
        if(newuser !=null)
        {
            foreach(var prp in newuser.GetType().GetProperties())
            {
                propertyNewValue.Add(prp.GetValue(olduser, null));
            }
        }
    
        /* Convert To JSON Here */
    
        return formattedJson;
    }
