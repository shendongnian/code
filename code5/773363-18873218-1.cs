    //Get the type
    var type= this.GetType();
    
    foreach (string key in Settings.Keys) 
    {
        //Get the property
        var property = type.GetProperty(key);
        //Convert the value to the property type
        var convertedValue = Convert.ChangeType(Settings[key], property.PropertyType);
        property.SetValue(this, convertedValue); 
    }
