    if(pinfo.PropertyType.IsArray)
    {
      // Grab the actual instance of the array.
      // We'll have to use it in a few spots.
      var array = pinfo.GetValue(personObject);
      // Get the length of the array and build an indexArray.
      int length = (int)pinfo.PropertyType.GetProperty("Length").GetValue(array);
    
      // Get the "GetValue" method so we can extact the array values
      var getValue = findGetValue(pinfo.PropertyType);
    
      // Cycle through each index and use our "getValue" to fetch the value from the array.
      for(int i=0; i<length; i++)
        fields.Add(new ObjectField { Name = pinfo.Name, Value = getValue.Invoke(array, new object[]{i}).ToString();
    }
    
    // Looks for the "GetValue(int index)" MethodInfo.
    private static System.Reflection.MethodInfo findGetValue(Type t)
    {
      return (from mi in t.GetMethods()
        where mi.Name == "GetValue"
        let parms = mi.GetParameters()
        where parms.Length == 1
        from p in parms
        where p.ParameterType == typeof(int)
        select mi).First();
    }
