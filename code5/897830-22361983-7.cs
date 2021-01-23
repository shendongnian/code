    [ContractAnnotation("parameter: null => halt")]
    public static void IfNull<T>([NotNull] T parameter,
                                 [InvokerParameterName] string parameterName) 
        where T : class
    {
        ...
    }
