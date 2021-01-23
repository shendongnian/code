    public void LogProps(Object object1)
    {
       var objType = object1.GetType();
    
       IList<PropertyInfo> properties = new List<PropertyInfo>(objType.GetProperties());
    
       foreach (PropertyInfo prop in properties)
       {
           var propValue = prop.GetValue(object1, null);
           if(prop.PropertyType == typeof(yourTypeHere))
           {  
              LogProps(propValue);
           }
           else
           {           
               logger.Debug(String.Format("{0} = {1}", prop.Name, propValue));
           }
       }
    }
