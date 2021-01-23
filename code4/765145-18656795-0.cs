    [DataContract]
    [KnownType(typeof(Option1))]
    [KnownType(typeof(Option2))]
    public abstract class BaseData
    {
        [DataMember]
        public int BaseVar1 { get; set; }        
    }
        
    [DataContract]
    public class Option1 : BaseData
    {
        [DataMember]
        public string Option1Var1 { get; set; }
    }
    
    [DataContract]
    public class Option2 : BaseData
    {
        [DataMember]
        public string Option2Var1 { get; set; }
    }
