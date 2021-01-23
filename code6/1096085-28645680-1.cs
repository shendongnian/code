    public static class Invoker {
        public static void Invoke(Proxy proxy, Expression<Func<Proxy,string>> online) {
            var methodName = ((MethodCallExpression)online.Body).Method.Name;
            if (IsCached(proxyName, methodName)) {
                output = GetFromCache(proxyName, methodName);
            } else {
                if (IsFuncCached(methodName)) {
                    func = GetFuncFromCache(methodName);
                } else {
                    func = online.Compile();
                    // add func to "func cache"...
                }
                output = func(proxy);
            }
        }
    }
