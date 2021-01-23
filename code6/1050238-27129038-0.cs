        /// <summary>
        /// Gets the Enum from a matching description value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="description"></param>
        /// <returns></returns>
        public static T GetValueFromDescription<T>(string description)
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description == description)
                    { 
                        return (T)field.GetValue(null);
                    }
                }
                else
                {
                    if (field.Name == description)
                    { 
                        return (T)field.GetValue(null);
                    }
                }
            }
            throw new ArgumentException("Enum description not found.", "Description");            
        }
