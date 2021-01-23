    // We can not use log4net ThreadContext or LogicalThreadContext with asp.net, since
    // asp.net may switch thread while serving a request, and reset the call context in
    // the process.
    public class HttpContextValueProvider : IFixingRequired
    {
        private string _contextKey;
        public HttpContextValueProvider(string contextKey)
        {
            _contextKey = contextKey;
        }
        public override string ToString()
        {
            var currContext = HttpContext.Current;
            if (currContext == null)
                return null;
            var value = currContext.Items[_contextKey];
            if (value == null)
                return null;
            return value.ToString();
        }
        object IFixingRequired.GetFixedObject()
        {
            return ToString();
        }
    }
