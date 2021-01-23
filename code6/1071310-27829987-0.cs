    public virtual Func<object, object> CreateBaseGetter(Type declaringType, PropertyInfo propertyInfo)
    {
      Func<object, object> nonProxyGetter = 
            ((Expression<Func<object, object>>) (instance 
                => 
                    Expression.PropertyOrField(
                        (Expression) Expression.Convert(instance, declaringType),
                        propertyInfo.Name))
            ).Compile();
