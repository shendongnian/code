    public object GetObjectType(object objectTypeName)
    {
        Type objecType = objectTypeName.GetType();
        //ur code works fine if do not have parameterised constructor
        return Activator.CreateInstance(objecType,"(do not forget to pass arguments)");
    }
