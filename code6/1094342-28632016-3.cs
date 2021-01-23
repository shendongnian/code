        private void SetModelPropertValues(object obj)
        {
            Type objType = obj.GetType();
            PropertyInfo[] properties = objType.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                object propValue = property.GetValue(obj, null);
                var elems = propValue as IList;
                if (elems != null)
                {
                    foreach (var item in elems)
                    {
                        this.SetModelPropertValues(item);
                    }
                }
                else
                {                   
                    if (property.PropertyType.Assembly == objType.Assembly)
                    {                        
                        this.SetModelPropertValues(propValue);
                    }
                    else
                    {
                      property.SetValue(obj, this.vp.GetValue(property.Name).AttemptedValue, null);
                    }
                }
            }
        }
