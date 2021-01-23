    private static void SetPublicProperties(Type type, object obj, Dictionary<Type, object> createdObjectReferences)
        {
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            ObjectGenerator objectGenerator = new ObjectGenerator();
            foreach (PropertyInfo property in properties)
            {
                if (property.IsDefined(typeof (TextSampleAttribute), false))
                {
                    object propertyValue = property.GetCustomAttribute<TextSampleAttribute>().Value;
                    property.SetValue(obj, propertyValue, null);
                }
                else if (property.CanWrite)
                {
                    object propertyValue = objectGenerator.GenerateObject(property.PropertyType, createdObjectReferences);
                    property.SetValue(obj, propertyValue, null);
                }
            }
        }
