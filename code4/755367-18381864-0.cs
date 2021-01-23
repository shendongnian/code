    [DataContract]
    [KnownType(typeof(A))]
    [KnownType(typeof(B))]
    public class SerializablionHelper
    {
      public SerializablionHelper()
      {
        //this.Entities = new Collection<Base>();
      }
        // public ICollection<Base> Entities { get; set; }
      public Base A { get; set; }
      public Base B { get; set; }
    }
    public abstract class Base
    {
    }
    [DataContract]
    public class A : Base
    {
      public int IntTest { get; set; }
      [DataMember]
      public string StringTest { get; set; }
    }
    [DataContract]
    public class B : Base
    {
      [DataMember]
      public int IntTest { get; set; }
      [DataMember]
      public string StringTest { get; set; }
    }
    public static void Main(string[] args)
    {
      var objectA = new A { IntTest = 5, StringTest = "TestA" };
      var objectB = new B { IntTest = 25, StringTest = "TestB" };
      var serList = new SerializablionHelper { A = objectA, B = objectB };
      var dcSerializer = new DataContractSerializer(typeof(SerializablionHelper));
      var xmlWriterSetting = new XmlWriterSettings() { Indent = true };
      using (var xmlWriter = XmlWriter.Create("C:\\test.xml", xmlWriterSetting))
      {
        dcSerializer.WriteObject(xmlWriter, serList);
      }
    }
