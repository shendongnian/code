    public sealed class MyClass
    {
        private static readonly GenericStaticMethod _deserializeHelper = new GenericStaticMethod(new Action<object, object, object>(DeserializeHelper<object>));
    }
    public sealed class GenericStaticMethod
    {
        private readonly MethodInfo methodToCall;
        public GenericStaticMethod(Delegate methodCall)
        {
            methodToCall = methodCall.Method.GetGenericMethodDefinition();
        }
    }
