    var myObject = Activator.CreateInstance(type);
    // Substitute code here to retrieve the property name/value pairs from the XML file 
    var myProperty = "GSetting1";
    var myValue = "ABC";
    var oProperty = type.GetProperty(myProperty, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Public);
    if (oProperty != null)
    {
        oProperty.SetValue(myObject, myValue, null);
    }
