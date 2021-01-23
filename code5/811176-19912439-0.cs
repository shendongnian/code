    public T Deserialize<T>(string entity)
        {
            var obj = Activator.CreateInstance<T>();
            var stringProps = entity.Split(',');
            var objProps = obj.GetType().GetProperties();
    
            var propIndex = 0;
    
            for (int i = 0; i < stringProps.Length; i++)
            {
                if (objProps[propIndex].PropertyType.FullName == "System.String")
                {
                    objProps[propIndex].SetValue(obj, stringProps[i], null);
                }
                else if (objProps[propIndex].PropertyType.FullName == "System.Int32")
                {
                    objProps[propIndex].SetValue(obj, Convert.ToInt32(stringProps[i]), null);
                }
                else if (objProps[propIndex].PropertyType.FullName == "System.DateTime")
                {
                    var cultureInfo = new CultureInfo("fa-IR");
                    DateTime dateTime = Convert.ToDateTime(stringProps[i], cultureInfo);
                    objProps[propIndex].SetValue(obj, stringProps[i], null);
                }
                else
                {
                    i--;
                }
                propIndex++;
            }
            return obj;
        }
