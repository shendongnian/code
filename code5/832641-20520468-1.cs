    void GetValue(string name)
    {
        ...
        foreach(PropertyInfo propertyInfo in typeof(Names).GetProperties())
        {
            if(propertyInfo.Name == name &&
               propertyInfo.CanRead)
            {
                strResult = propertyInfo.GetValue(null, null);
                return;
            }
        }
        //throw an excetion when the name does not exist
        throw new ArgumentExcetion(string.Format("There is no name \"{0}\"",name)); 
    }
