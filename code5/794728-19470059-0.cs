            foreach (var property in this.allProperties)
            {
              var propertyItself = element.GetType().GetProperty(property.GetType().Name);
              if(propertyItself!=null && propertyItself.PropertyType!=null)
               {
                    if (propertyItself.PropertyType != typeof(Int32)) 
                    { continue; }
    
                    if ((int)propertyItself.GetValue(element, null) == 0)
                     { return false; }
                }
             }
