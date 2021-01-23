    protected static IDictionary<string, object> GetProperties(ViewModelBase viewModel)
    {
        return viewModel._propertyValues;
    } 
    protected Delegate GetPropertiesFunc()
    {
        Type funcType = typeof(Func<,>).MakeGenericType(this.GetType(), typeof(IDictionary<String,object>));
        MethodInfo method = typeof(ViewModelBase).GetMethod("GetProperties",
            BindingFlags.NonPublic | BindingFlags.Static
        );
        return Delegate.CreateDelegate(funcType, method);
    } 
