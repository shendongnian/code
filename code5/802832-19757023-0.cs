    public enum MyClassType
    {
        TypeOne,
        TypeTwo
    }
    [AttributeUsage(AttributeTargets.Class)]
    public class MyMetadataAttribute: Attribute
    {
        public MyMetadataAttribute(MyClassType type)
        {
            Type = type;
        }
        public MyClassType Type { get; private set; }
    }
	
