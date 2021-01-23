    [System.AttributeUsage(System.AttributeTargets.Enum)]
    public class CustomDataAttribute : System.Attribute
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
