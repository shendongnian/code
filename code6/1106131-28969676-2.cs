    ...
    var arrayOfIntegers, arrType, enumType, enumParameter;
    begin
      // Create a .NET array, e.g. {5}
      arrType := dotNET.System.Type.GetType('System.Int32');
      arrayOfIntegers := dotNET.System.Array.CreateInstance(arrType, 1);
      arrayOfIntegers.SetValue(5, 0);
    
      // Create an enumeration value, e.g. DayOfWeek.Tuesday
      enumType := dotNET.System.Type.GetType('System.DayOfWeek');
      enumParameter := dotNET.System.Enum.Parse(enumType, 'Tuesday');
    
      functionResult := CSharpLibrary.CSharpFunction(arrayOfIntegers, enumParameter);
    end;
