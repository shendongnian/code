     var t = typeof(YourClass);
     var properties = t.GetProperties();
     var keyProps = new List<string>();
    
    foreach (var prop in properties) 
    {
         if (Attribute.IsDefined(prop , typeof(Key)))
         {
             keyProps.Add(prop.Name);
         }
    }
