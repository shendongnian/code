    PropertyInfo prop = commandObject.GetType().GetProperty("Id");
    if(null != prop && prop.CanWrite)
    {
        prop.SetValue(commandObject, "Id", 3);
    }
