    bool IsAnyNullOrEmpty(object myObject)
    {
        foreach(PropertyInfo pi in myObject.GetType().GetProperties())
        {
            string value = (string)pi.GetValue(myObject);
            if(String.IsNullOrEmpty(value))
            {
                return false;
            }
        }
        return true;
    }
