    public static class Invoker
    {
        public static void invoke(Proxy proxy, Func<Proxy, string> online)
        {
           //Some caching logic that require the name of the method 
           //invoked on the proxy (in this specific case "formatSomething")    
           var methodName = online.Method.Name;
        }
    }
