        private Dictionary<String, object> ConvertToDictionary(object classToSerialize)
        {
            Dictionary<String, object> resultDictionary = new Dictionary<string, object>();
            foreach (var propertyInfo in classToSerialize.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (propertyInfo.CanWrite) resultDictionary.Add(propertyInfo.Name, propertyInfo.GetValue(classToSerialize, null));
            }
            return resultDictionary;
        }
