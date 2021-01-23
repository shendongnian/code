    [DataContract]
    [KnownType(typeof(Class1))]
    [KnownType(typeof(Class2))]
    public abstract class MainBaseClass
    {
        [DataMember]
        public int Id { get; set; } // For instance.
    }
    [DataContract]
    public class Class1 : MainBaseClass
    {
        [DataMember]
        public int attrib1 { get; set; }
        [DataMember]
        public int attrib2 { get; set; }
    }
    [DataContract]
    public class Class2 : MainBaseClass
    {
        [DataMember]
        public int attribx { get; set; }
        [DataMember]
        public int attriby { get; set; }
    }
