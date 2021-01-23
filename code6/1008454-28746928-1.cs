    public class PropertiesMiddleware : OwinMiddleware
    {
        Dictionary<string, object> _properties = null;
        public PropertiesMiddleware(OwinMiddleware next, Dictionary<string, object> properties)
            : base(next)
        {
            _properties = properties;
        }
        public async override Task Invoke(IOwinContext context)
        {
            if (_properties != null)
            {
                foreach (var prop in _properties)
                    if (context.Get<object>(prop.Key) == null)
                    {
                        context.Set<object>(prop.Key, prop.Value);
                    }
            }
            await Next.Invoke(context);
        }
    }
