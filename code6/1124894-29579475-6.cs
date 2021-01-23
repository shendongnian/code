    class Sample
    {
        [Required(ErrorMessage = "The Year of Manufacture has to be filled")]
        public int? YearOfManufacture { get; set; }
        public int? NotAttributedProperty { get; set; }
    }
    static class Annotations
    {
        public static T GetAttributeFrom<T>(this object instance, string propertyName) where T : Attribute
        {
            var attrType = typeof(T);
            var property = instance.GetType().GetProperty(propertyName);
            return (T)property.GetCustomAttributes(attrType, false).FirstOrDefault();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var sampleInstance = new Sample();
            var annotation = sampleInstance.GetAttributeFrom<RequiredAttribute>("YearOfManufacture");
            var nullAnnotation = sampleInstance.GetAttributeFrom<RequiredAttribute>("NotAttributedProperty");
        }
    }
