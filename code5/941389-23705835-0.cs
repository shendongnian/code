            Dictionary<string, string> propertyValues = new Dictionary<string, string>();
            // We access the type information via reflection. What properties your someObject has?
            PropertyInfo[] propertyInfos = someObject.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (var propertyInfo in propertyInfos)
            {
                // we get the value of the property, described by propertyInfo, from our someObject 
                object value = propertyInfo.GetValue(someObject, null);
                if (value != null)
                {
                    // do your special type handling here and execute ToString()
                    if(value.GetType() == typeof(int) || ...)
                        propertyValues[propertyInfo.Name] = value.ToString("F");
                    else
                        propertyValues[propertyInfo.Name] = value.ToString();
                }
            }
            // so if your someObject had a property A you can access it as follows:
            string A = propertyValues["A"];
            // or you loop the dictionary and do some suff with it (which makes much more sense):
            foreach(var keyValuePair in propertyValues)
                Console.WriteLine("Property {0} = {1}", keyValuePair.Key, keyValuePair.Value);
