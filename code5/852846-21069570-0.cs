    private static Dictionary<Type, Func<IInterface, bool>> _validationFunctions
       = new Dictionary<Type, Func<IInterface, bool>>() {
           { typeof(ClassA), (input) => false },
           { typeof(ClassB), (input) => true }
       };
    public static bool RequestIsValid(IInterface preAuthorizeRequest)
    {
        return _validationFunctions[preAuthorizeRequest.GetType()](preAuthorizeRequest);
    }
