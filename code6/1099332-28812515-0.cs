    public class FooProxyGenerationHook : IProxyGenerationHook
    {
        public void MethodsInspected()
        { }
        public void NonProxyableMemberNotification(Type type, MemberInfo memberInfo)
        { }
        public Boolean ShouldInterceptMethod(Type type, MethodInfo methodInfo)
        {
            if (type == typeof(Foo) && methodInfo.Name == "Do")
            {
                return true;
            }
            return false;
        }
    }
