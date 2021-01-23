    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class ApplicationExtensionAttribute : ExportAttribute, IApplicationExtensionMetadata
    {
        public ApplicationExtensionAttribute(/* ... */)
            : base(typeof(IApplicationExtension))
        {
            this.Name = name;
            this.UICompositionOrder = uiCompositionOrder;
        }
       // ...
    }
