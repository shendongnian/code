    //Get the type
    var type= this.GetType();
    
    foreach (string key in Settings.Keys) 
    {
        //Get the property
        var property = type.GetProperty(key);
        //Convert the value to the property type
        var convertedValue = Convert.ChangeType(property.PropertyType, Settings[key]);
        property.SetValue(this, convertedValue); 
    }
