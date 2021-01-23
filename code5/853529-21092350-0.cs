    if(pinfo.PropertyType.IsArray)
    {
      var array = pinfo.GetValue(personObject);
    
      // Is in fact an array...
      // Get the length of the array and build an indexArray.
      int length = (int)pinfo.PropertyType.GetProperty("Length").GetValue(array);
    
      // Get the "GetValue" method so we can extact the array values
      getValue = findGetValue(pinfo.PropertyType);
    
      for(int i=0; i<length; i++)
        fields.Add(new ObjectField { Name = pinfo.Name, Value = getValue(array, new object[]{i}).ToString();
    }
    
    // Looks for the "GetValue(int index)" MethodInfo.
    public System.Reflection.MethodInfo findGetValue(Type t)
    {
      return (from mi in t.GetMethods()
        where mi.Name == "GetValue"
        let parms = mi.GetParameters()
        where parms.Length == 1
        from p in parms
        where p.ParameterType == typeof(int)
        select mi).First();
    }
