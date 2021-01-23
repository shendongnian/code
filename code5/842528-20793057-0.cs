    PropertyInfo[] propList = obj.GetType().GetProperties(); //This will get all property with property name
    foreach (PropertyInfo pInfo in propList)
    {
        if (pInfo.PropertyType == typeof(int) || pInfo.PropertyType == typeof(string))
        {
            //Just get the value and insert to your table
            object propValue = pInfo.GetValue(obj, null); //Notice this is not fit for array type
        }
        else
        {
            //This is embeded object
            string thisPropName = pInfo.Name; //Get the property name. Here should be UserType
            object propValue = pInfo.GetValue(obj, null); //Then you can use this object to get its inside property name and value with same method above.
        }
        
        
    }
