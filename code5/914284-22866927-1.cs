    /// <summary>
    /// Add this to the global configuration Formatters collection to accept json-patch requests
    /// </summary>
    public class JsonPatchMediaTypeFormatter : JsonMediaTypeFormatter
    {
        public JsonPatchMediaTypeFormatter() : base()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json-patch"));
        }
    }
    /// <summary>
    /// All possible values for the "op" property of a json-patch object
    /// docs: http://tools.ietf.org/html/rfc6902#section-4
    /// </summary>
    public enum JsonPatchOperationType
    {
        add,
        remove,
        replace,
        move,
        copy,
        test
    }
    /// <summary>
    /// json-patch is a partial update format for HTTP PATCH requests
    /// docs: http://tools.ietf.org/html/rfc6902
    /// </summary>
    public class JsonPatchOperation
    {
        public string op { get; set; }
        public string from { get; set; }
        public string path { get; set; }
        public string value { get; set; }
        public Func<PropertyInfo, object, object> GetForeignKeyObject { get; set; }
        public JsonPatchOperationType Operation
        {
            get
            {
                return (JsonPatchOperationType)Enum.Parse(typeof(JsonPatchOperationType), op);
            }
        }
        public void ApplyTo(object document)
        {
            switch (Operation)
            {
                case JsonPatchOperationType.add:
                    Add(document, path, value);
                    break;
                case JsonPatchOperationType.remove:
                    Remove(document, path);
                    break;
                case JsonPatchOperationType.replace:
                    Replace(document, path, value);
                    break;
                case JsonPatchOperationType.move:
                    Move(document, path, from);
                    break;
                case JsonPatchOperationType.copy:
                    Copy(document, path, from);
                    break;
                case JsonPatchOperationType.test:
                    Test(document, path, value);
                    break;
            }
        }
        private void Add(object document, string path, string value)
        {
            Type documentType = document.GetType();
            PathInfo pathInfo = GetPathInfo(documentType, path);
            object convertedValue = ConvertToType(value, pathInfo.PropertyInfo.PropertyType);
            pathInfo.PropertyInfo.SetValue(document, convertedValue, pathInfo.Indexes);
        }
        private void Replace(object document, string path, string value)
        {
            Type documentType = document.GetType();
            PathInfo pathInfo = GetPathInfo(documentType, path);
            object convertedValue = ConvertToType(value, pathInfo.PropertyInfo.PropertyType);
            try
            {
                pathInfo.PropertyInfo.SetValue(document, convertedValue, pathInfo.Indexes);
            }
            // gnarly hack for setting foreign key properties
            catch (TargetInvocationException tie)
            {
                if (tie.InnerException is ForeignKeyReferenceAlreadyHasValueException)
                {
                    PropertyInfo matchingProperty = documentType.GetProperties().Single(p => p.GetCustomAttributes(typeof(AssociationAttribute), true).Any(attr => ((AssociationAttribute)attr).ThisKey == pathInfo.PropertyInfo.Name));
                    matchingProperty.SetValue(document, GetForeignKeyObject(matchingProperty, convertedValue), null);
                }
                else
                {
                    throw tie;
                }
            }
        }
        private void Remove(object document, string path)
        {
            Type documentType = document.GetType();
            PathInfo pathInfo = GetPathInfo(documentType, path);
            pathInfo.PropertyInfo.SetValue(document, GetDefaultValue(pathInfo.PropertyInfo.PropertyType), pathInfo.Indexes);
        }
        private void Copy(object document, string path, string from)
        {
            throw new NotImplementedException();
        }
        private void Move(object document, string path, string from)
        {
            throw new NotImplementedException();
        }
        private void Test(object document, string path, string value)
        {
            throw new NotImplementedException();
        }
        #region Util
        private class PathInfo
        {
            public PropertyInfo PropertyInfo { get; set; }
            public object[] Indexes { get; set; }
        }
        private PathInfo GetPathInfo(Type documentType, string path)
        {
            object[] indexes = null;
            PropertyInfo propertyInfo = documentType.GetProperty(path);
            return new PathInfo { PropertyInfo = propertyInfo, Indexes = indexes };
        }
        private object GetDefaultValue(Type t)
        {
            if (t.IsValueType)
                return Activator.CreateInstance(t);
            return null;
        }
        private object ConvertToType(string value, Type type)
        {
            TypeConverter typeConverter = TypeDescriptor.GetConverter(type);
            return typeConverter.ConvertFromString(value);
        }
        #endregion
    }
