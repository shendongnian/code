    public interface IMyPlugin {}
    public interface IMyMetadata
    {
        int Value1 { get; }
        string Value2 { get; }
    }
    
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class MyExportAttribute : ExportAttribute, IMyMetadata
    {
        public MyExportAttribute(int value1, string value2)
            : base(typeof(IMyPlugin))
        {
            Value1 = value1;
            Value2 = value2;
        }
    
        public int Value1 { get; private set; }
        public string Value2 { get; private set; }
    }
