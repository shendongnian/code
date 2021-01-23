    bool IsAnyNullOrEmpty(object myObject)
    {
        foreach(PropertyInfo pi in myObject.GetType().GetProperties())
        {
            if(pi.PropertyType == typeof(string))
            {
                string value = (string)pi.GetValue(myObject);
                if(string.IsNullOrEmpty(value))
                {
                    return false;
                }
            }
        }
        return true;
    }
