            if (prop.PropertyType.IsGenericType)
            {
                if (prop.PropertyType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                {
                    Type typeParameter = prop.PropertyType.GetGenericArguments()[0];
                    var i = prop.GetValue(initial);
                    var f = prop.GetValue(final);  
                    if(object.Equals(i,f))
                    {
                        //...
                    }
                }
            }
