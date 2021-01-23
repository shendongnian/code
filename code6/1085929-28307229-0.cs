    public interface IDeserializable
    {
        void OnDeserialize();
    }
    public class A
    {
        [XmlElement(ElementName = "Something", Form = XmlSchemaForm.Unqualified)]
        public string Something { get; set; }
    }
    public class B : A, IDeserializable
    {
        [System.Xml.Serialization.XmlIgnore]
        public Int32 SomethingInt32
        {
            get;
            set;
        }
        public void OnDeserialize()
        {
            SomethingInt32 = Int32.Parse(Something);
        }
    }
    public class C
    {
        public void Deserialize()
        {
            System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(B));
            var b = ser.Deserialize(streamOrStringData) as B;
            b.OnDeserialize();
        }
    }
