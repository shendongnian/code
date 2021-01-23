    // Get the value of a property of an object or a default
    // value if the object is null.
    public static TProperty GetGetPropertyValueOrDefault<TObject, TProperty>(this TObject obj, Func<TObject, TProperty> propertyValueGetter, TProperty defaultValue = default(TProperty))
       where TObject : class
    {
       return (obj != null) ? propertyValueGetter(obj) : defaultValue;
    }
    // Get the value of a property for the single object in a
    // sequence or a default value if the sequence is empty.
    public static TProperty GetSinglePropertyValueOrDefault<TObject, TProperty>(this IEnumerable<TObject> sequence, Func<TObject, TProperty> propertyValueGetter, TProperty defaultValue = default(TProperty))
       where TObject : class
    {
        return sequence.SingleOrDefault().GetGetPropertyValueOrDefault(propertyValueGetter, defaultValue);
    }
    // Get the value of a property or a default value if the
    // object is null for all objects in a sequence.
    public static IEnumerable<TProperty> GetGetPropertyValuesOrDefault<TObject, TProperty>(this IEnumerable<TObject> sequence, Func<TObject, TProperty> propertyValueGetter, TProperty defaultValue = default(TProperty))
       where TObject : class
    {
        return sequence.Select(element => element.GetGetPropertyValueOrDefault(propertyValueGetter, defaultValue));
    }
