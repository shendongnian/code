    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class TransformDataAttribute : Attribute
    {
        public string TransformDataClass { get; set; }
        // This method must contain these parameters: (object value, PropertyInfo pi)
        public string TransformDataMethod { get; set; }
    }
