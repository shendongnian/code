    [ServiceContract(Namespace = "http://my.site/rev2015")]
    [XmlSerializerFormat]
    public interface IService1
    {
      [OperationContract]
      [XmlSerializerFormat]
      CompositeType GetDataUsingDataContract(CompositeType composite);
    }
    [MessageContract(WrapperNamespace = "http://my.site/rev2015", IsWrapped = true)]
    public class InnerType
    {
      [MessageBodyMember(Namespace = "http://my.site/rev2015")]
      public bool ANotherBool;
      [MessageBodyMember(Namespace = "http://my.site/rev2015")]
      public string AnotherStringValue;
    }
