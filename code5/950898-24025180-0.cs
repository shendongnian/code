    [DataContract(Namespace = "namespace")]
    [KnownType(typeof(KnownType1))]
    public class DataContract
    {
        [DataMember(IsRequired = true)]
        public int Value;
    }
    
    [DataContract(Namespace = "namespace1")]
    public sealed class KnownType1 : DataContract
    {
        [DataMember(IsRequired = true)]
        public int Value1;
    }
