    [ContentProperty("Name")]
    public class NameReferenceExtension : MarkupExtension
    {
        [ConstructorArgument("name")]
        public string Name { get; set; }
        public NameReferenceExtension() {}
        public NameReferenceExtension(string name)
        {
            this.Name = name;
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
                throw new ArgumentNullException("serviceProvider");
            var xamlNameResolver = serviceProvider.GetService(typeof(IXamlNameResolver))
                                   as IXamlNameResolver;
            if (xamlNameResolver == null)
                return null; // fail silently
            if (string.IsNullOrEmpty(this.Name))
                throw new InvalidOperationException(
                    "Name is required when using NameReference.");
            var resolved = xamlNameResolver.Resolve(this.Name);
            if (resolved == null)
                resolved = xamlNameResolver.GetFixupToken(new[] { this.Name }, true);
            return resolved;
        }
    }
