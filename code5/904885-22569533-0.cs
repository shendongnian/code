    var type = myObject.GetType();
    foreach (var field in type.GetFields())
    {
        string value = (string)field.GetValue(myObject);
        if (string.IsNullOrEmpty(value))
        {
            UpdateFromMethod(field.Name);
        }
    }
