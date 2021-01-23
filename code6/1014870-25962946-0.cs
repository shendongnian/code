    public static class Helper
    {
        public static void SetProperty(object instance, string propery, object value)
        {
            const BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
            var properties = propery.Split('.');
            var type = instance.GetType();
            object[] index = null;
            PropertyInfo property = null;
            for (var i = 0; i < properties.Length; i++)
            {
                var indexValue = Regex.Match(properties[i], @"(?<=\[)(.*?)(?=\])").Value;
                if (string.IsNullOrEmpty(indexValue))
                {
                    property = type.GetProperty(properties[i], flags);
                    index = null;
                }
                else
                {
                    property =
                        type.GetProperty(properties[i].Replace(string.Format("[{0}]", indexValue), string.Empty),
                            flags);
                    index = GetIndex(indexValue, property);
                }
                if (i < properties.Length - 1)
                    instance = property.GetValue(instance, index);
                type = instance.GetType();
            }
            property.SetValue(instance, value, index);
        }
        public static object GetProperty(object instance, string propery)
        {
            const BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
            var properties = propery.Split('.');
            var type = instance.GetType();
            foreach (var p in properties)
            {
                var indexValue = Regex.Match(p, @"(?<=\[)(.*?)(?=\])").Value;
                object[] index;
                PropertyInfo property;
                if (string.IsNullOrEmpty(indexValue))
                {
                    property = type.GetProperty(p, flags);
                    index = null;
                }
                else
                {
                    property =
                        type.GetProperty(p.Replace(string.Format("[{0}]", indexValue), string.Empty),
                            flags);
                    index = GetIndex(indexValue, property);
                }
                instance = property.GetValue(instance, index);
                type = instance.GetType();
            }
            return instance;
        }
        private static object[] GetIndex(string indicesValue, PropertyInfo property)
        {
            var parameters = indicesValue.Split(',');
            var parameterTypes = property.GetIndexParameters();
            var index = new object[parameterTypes.Length];
            for (var i = 0; i < parameterTypes.Length; i++)
                index[i] = parameterTypes[i].ParameterType.IsEnum
                    ? Enum.Parse(parameterTypes[i].ParameterType, parameters[i])
                    : Convert.ChangeType(parameters[i], parameterTypes[i].ParameterType);
            return index;
        }
    }
