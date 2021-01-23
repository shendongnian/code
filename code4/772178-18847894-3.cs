    public static void CopyPropertyValues(object source, object destination) {
        // just a check to make sure the following lines won't backfire
        if ((null == source) || (null == destination))
            throw new ArgumentNullException();
   
        // we'll need to also check that the 2 objects are of the same type
        var type = source.GetType();
        if (destination.GetType() != type)
            throw new ArgumentException("The two objects should be of the same type");
        var properties = type.GetProperties()
            // just filter out the properties which are indexers (if any)
            // and also those properties which are read or write only
            .Where(property => (property.GetIndexParameters().Length == 0) &&
                               property.CanRead && property.CanWrite);
        foreach (var property in properties) {
            var sourceValue = property.GetValue(source, null);
            var destValue = property.GetValue(destination, null);
            if (!IsDefaultValue(sourceValue) && IsDefaultValue(destValue))
                property.SetValue(destination, sourceValue, null);
        }
    }
