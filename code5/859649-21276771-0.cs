    foreach (PropertyInfo item in propertyInfos)
            {
                Object value;
                if (item.GetIndexParameters().Length == 0)
                {
                    value = item.GetValue(vehicles, null);
                }
                else
                {
                    value = item.GetValue(vehicles, new object[] { 0 });  // string property is returned as a char array and consequently need index
                }
                Type  type = value == null ? item.PropertyType : value.GetType();
                Console.WriteLine(type.Name);
            }
