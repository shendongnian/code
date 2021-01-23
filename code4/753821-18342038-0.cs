    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class PostalCodeAttribute : RegularExpressionAttribute
    {
        private static ConcurrentDictionary<string, Func<string, string>> _resolverDict = new ConcurrentDictionary<string, Func<string, string>>();
        private static string Resolve(string source)
        {
            Func<string, string> resolver = null;
            if (!_resolverDict.TryGetValue(source, out resolver))
                throw new InvalidOperationException(string.Format("No resolver for {0}", source));
            return resolver(source);
        }
        public static void RegisterResolver(string source, Func<string, string> resolver)
        {
            _resolverDict.AddOrUpdate(source, resolver, (s, c) => resolver);
        }
        static PostalCodeAttribute()
        {
            // necessary to enable client side validation
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(PostalCodeAttribute), typeof(RegularExpressionAttributeAdapter));
        }
        public PostalCodeAttribute(string patternSource)
            : base(Resolve(patternSource))
        {
        }
    }
    
    /// ...
    public void SomeIntializer()
    {
        PostalCodeAttribute.RegisterResolver("db_source", (s) => PostalCodeRegularExpressions.LookupFromDatabase());
    }
    public class SomeClassWithDataValidation
    {
        [PostalCode("db_source")]
        public string PostalCode { get; set; }
    }
