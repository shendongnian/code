    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class QueryAttribute : Attribute
    {
        public string QueryString { get; private set; }
    
        public QueryAttribute(string queryString)
        {
            QueryString = queryString;
        }
        public static string GetQueryStringForType(Type type)
        {
            var queryAttr = typeof(T).GetCustomAttributes(typeof(QueryAttribute), false)
                                     .FirstOrDefault() as QueryAttribute;
            return queryAttr != null ? queryAttr.QueryString : null;
        }
    }
