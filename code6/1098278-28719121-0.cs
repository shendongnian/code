        public static IBindingNamedWithOrOnSyntax<T> InSessionScope<T>(this IBindingInSyntax<T> parent)
        {
           return parent.InScope(SessionScopeCallback);
        }
        public static Dictionary<string, object> LocalSessionStore = new Dictionary<string, object>();
        private const string _sessionKey = "Ninject Session Scope Sync Root";
        private static object SessionScopeCallback(IContext context)
        {
            var obj = new object();
            var key = (string)HttpContext.Current.Session[_sessionKey];
            if (string.IsNullOrEmpty(key))
            {
                var guid = Guid.NewGuid().ToString();
                HttpContext.Current.Session[_sessionKey] = guid;
                LocalSessionStore.Add(guid, obj);
            }
            else if(!LocalSessionStore.ContainsKey(key))
            {
                LocalSessionStore.Add(key, obj);
                return LocalSessionStore[key];
            }
            else if (LocalSessionStore.ContainsKey(key))
            {
                return LocalSessionStore[key];
            }
            return HttpContext.Current.Session[_sessionKey];
        }
    }
