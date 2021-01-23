    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    class PlugInMetadataAttribute : ExportAttribute, IPlugInMetadata
    {
        public PlugInMetadataAttribute()
            : base(typeof(IPlugIn))
        {
        }
        public PlugInMetadataAttribute(string contractName)
            : base(contractName, typeof(IPlugIn))
        {
        }
        public string Name { get; set; }
    }
