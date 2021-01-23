    public static void SomeMethod<TProperty>(Expression<Func<TProperty>> property)
    {
        var propertyName = property.Name;
        // Do something,
    }
    public static void SomeMethod<TProperty>(PropertyInfo property)
    {
        SomeMethod(Expression.Lambda<Func<TProperty>>(Expression.Property(null, property)));
    }
    static void EventHandler(object sender, PropertyChangedEventArgs e)
    {
        var propertyInfo = sender.GetType().GetProperty(e.PropertyName);
        var someMethod = this.GetType().GetMethod("SomeMethod", BindingFlags.Public | BindingFlags.Static, null, new[] { typeof(PropertyInfo) }, null);
        someMethod.Invoke(null, new[] { propertyInfo });
    }
