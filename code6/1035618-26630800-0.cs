    public static void Extension(this Abstract a)
    {
        var actualType = a.GetType();
        var interestingBaseType = ...search basetypes of actualType for Abstract<T>
        var theTypeParameter = interestingBaseType.GetGenericArguments()[0];
        var genericMethodDef = typeof(Extensions).GetMethod("Extension");
        var concreteMethod = genericMethodDef.MakeGenericMethod(theTypeParameter);
        concreteMethod.Invoke(a, ....);
    }
