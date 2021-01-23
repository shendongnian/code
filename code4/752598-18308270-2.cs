    public static void SomeMethod<TProperty>(Expression<Func<TProperty>> property)
    {
        var propertyName = property.Name;
        // Do something,
    }
        
    public static void SomeMethod<TProperty>(object sender, PropertyInfo property)
    {
        SomeMethod(Expression.Lambda<Func<TProperty>>(Expression.Property(Expression.Constant(sender), property)));
    }
    public static MethodInfo someMethod = typeof(Program).GetMethod("SomeMethod", BindingFlags.Public | BindingFlags.Static, null, new[] { typeof(object), typeof(PropertyInfo) }, null);
    static void EventHandler(object sender, PropertyChangedEventArgs e)
    {
        var propertyInfo = sender.GetType().GetProperty(e.PropertyName);
        someMethod.MakeGenericMethod(propertyInfo.PropertyType).Invoke(null, new[] { sender, propertyInfo });
    }
