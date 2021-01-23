    private bool validateProperty(string propertyName)
    {            
        string value = GetType().GetProperty(propertyName).GetValue(this, null) as string;
        if (value != null)
        {
            var list = new List<String> { "FirstName", "LastName", "BusinessItem", "BusinessItems" };
            value = value.Trim();
            if (!string.IsNullOrEmpty(value))
                return list.Contains(value);
        }
    
        return false;    
    }
    public string this[string columnName]
    {
        get
        {
            // if you validate more properties, you may want to check if columnName
            // follows a pattern (eg. columnName.Contains("ListItem") )
            
           if (!validateProperty(columName))
              return "Please enter either FirstName, LastName, BusinessItem, or BusinessItems";
           return string.Empty;
         }
    }
