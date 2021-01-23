    var objectList = new List<DataObject>();
    var enumValues = new List<MyEnum>();
    foreach (var obj in objectList)
    {
         foreach (var prop in properties)
         {
            enumValues.Add((MyEnum)prop.GetValue(obj));
         }
    }
