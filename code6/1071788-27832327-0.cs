    public class NoParameterlessConstructor
    {
        public string Value { get; set; }
        public NoParameterlessConstructor(string value)
        {
            this.Value = value;
        }
    }
    public class BaseClass
    {
        public NoParameterlessConstructor NoParameterlessConstructor { get; set; }
    }
    public class DerivedClass : BaseClass
    {
        static XmlSerializer serializer = null;
        static DerivedClass()
        {
            var xOver = new XmlAttributeOverrides();
            var attrs = new XmlAttributes() { XmlIgnore = true };
            xOver.Add(typeof(BaseClass), "NoParameterlessConstructor", attrs); // Must use BaseClass here not DerivedClass!
            serializer = new XmlSerializer(typeof(DerivedClass), xOver);
        }
        public static XmlSerializer DerivedClassXmlSerializer { get { return serializer; } }
        public int Id { get; set; }
    }
