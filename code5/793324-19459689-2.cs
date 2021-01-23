        private static int GetPathDepth(string path)
        {
            int depth = 0;
            for (int i = 0; i < path.Length; i++)
            {
                if (path[i] == '.')
                {
                    depth++;
                }
            }
            return depth;
        }
        private static string GetPathAtDepth(string path, int depth)
        {
            StringBuilder pathBuilder = new StringBuilder();
            string[] pathParts = path.Split('.');
            for (int i = 0; i < depth && i < pathParts.Length; i++)
            {
                string pathPart = pathParts[i];
                if (i == depth - 1 || i == pathParts.Length - 1)
                {
                    pathBuilder.Append(pathPart);
                }
                else
                {
                    pathBuilder.AppendFormat("{0}.", pathPart);
                }
            }
            string pathAtDepth = pathBuilder.ToString();
            return pathAtDepth;
        }
        private static string[] GetIntermediatePaths(string path)
        {
            int depth = GetPathDepth(path);
            string[] intermediatePaths = new string[depth];
            for (int i = 0; i < intermediatePaths.Length; i++)
            {
                string intermediatePath = GetPathAtDepth(path, i + 1);
                intermediatePaths[i] = intermediatePath;
            }
            return intermediatePaths;
        }
        private static PropertyInfo GetProperty(Type root, string path)
        {
            PropertyInfo result = null;
            string[] pathParts = path.Split('.');
            foreach (string pathPart in pathParts)
            {
                if (Object.ReferenceEquals(result, null))
                {
                    result = root.GetProperty(pathPart);
                }
                else
                {
                    result = result.PropertyType.GetProperty(pathPart);
                }
            }
            if (Object.ReferenceEquals(result, null))
            {
                throw new ArgumentException("A property at the specified path could not be located.", "path");
            }
            return result;
        }
        private static object GetParameter(ParameterInfo parameter, Dictionary<string, string> valueMap)
        {
            Type root = parameter.ParameterType;
            Dictionary<string, object> instanceMap = new Dictionary<string, object>();
            foreach (KeyValuePair<string, string> valueMapEntry in valueMap)
            {
                string path = valueMapEntry.Key;
                string value = valueMapEntry.Value;
                string[] intermediatePaths = GetIntermediatePaths(path);
                foreach (string intermediatePath in intermediatePaths)
                {
                    PropertyInfo intermediateProperty = GetProperty(root, intermediatePath);
                    object propertyTypeInstance;
                    if (!instanceMap.TryGetValue(intermediatePath, out propertyTypeInstance))
                    {
                        propertyTypeInstance = Activator.CreateInstance(intermediateProperty.PropertyType);
                        instanceMap.Add(intermediatePath, propertyTypeInstance);
                    }
                }
                PropertyInfo property = GetProperty(root, path);
                TypeConverter converter = TypeDescriptor.GetConverter(property.PropertyType);
                object convertedValue = converter.ConvertFrom(value);
                instanceMap.Add(path, convertedValue);
            }
            object rootInstance = Activator.CreateInstance(root);
            foreach (KeyValuePair<string, object> instanceMapEntry in instanceMap)
            {
                string path = instanceMapEntry.Key;
                object value = instanceMapEntry.Value;
                PropertyInfo property = GetProperty(root, path);
                object instance;
                int depth = GetPathDepth(path);
                if (depth == 0)
                {
                    instance = rootInstance;
                }
                else
                {
                    string parentPath = GetPathAtDepth(path, depth);
                    instance = instanceMap[parentPath];
                }
                property.SetValue(instance, value);
            }
            return rootInstance;
        }
