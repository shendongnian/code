     object value = descriptor.GetValue(object1);
    
     if (descriptor.PropertyType == typeof(the type that you expecting) ) 
     {
        foreach (PropertyDescriptor innerdescriptor in TypeDescriptor.GetProperties(value) 
        {
             string innername = innerdescriptor.Name;
             object innervalue = innerdescriptor.GetValue(object2);
             logger.Debug(String.Format("     {0} = {1}", innername, innervalue));
        }
     } // end if
