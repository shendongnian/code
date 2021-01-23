    public static class ExtensionMethods
    {
        public static object test_method(this PyroProxy proxy, params object[] arguments)
        {
            return proxy.call("test_method", arguments); // you get the point
        }
    }
