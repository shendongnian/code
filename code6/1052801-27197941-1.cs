    var myObject = Activator.CreateInstance(type);
    // Substitute code here to retrieve the property name/value pairs from the XML file 
    var myProperty = "GSetting1";
    var myValue = "ABC";
    // See if the requested property actually exists in the class
    var oProperty = type.GetProperty(myProperty, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Public);
    if (oProperty != null)
    {
        // If it does, set its value based on what was retrieved from the XML file
        oProperty.SetValue(myObject, myValue, null);
    }
