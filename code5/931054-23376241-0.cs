    [MarkupExtensionReturnType(typeof(string))]
    public class MyExtension : MarkupExtension
    {
        public MyExtension(string resourceKey)
        {
            ResourceKey = resourceKey;
        }
        string ResourceKey { get; set; }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var staticResourceExtension = new StaticResourceExtension(ResourceKey);
            
            var resource = staticResourceExtension.ProvideValue(serviceProvider) as Item;
            
            return resource == null ? "Invalid Item" : String.Format("My {0} {1}", resource.Value, resource.Title);
        }
    }
