    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ExportViewModelAttribute : ExportAttribute, IViewModelMetadata
    {
        public ExportViewModelAttribute(Type declaredType)
            : base(null, typeof(IViewModel))
        {
            this.DeclaredType = declaredType;
        }
         
        public Type DeclaredType { get; private set; }
    }
