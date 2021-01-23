    public enum Options
    {
        Option1,
        Option2
    }
    [DataContract]
    [KnownType(typeof(Option1))]
    [KnownType(typeof(Option2))]
    public abstract class BaseData
    {
        [DataMember]
        public int BaseVar1 { get; set; }        
        [IgnoreDataMember]
        public abstract Options Option {get;}
    }
        
    [DataContract]
    public class Option1 : BaseData
    {
        [DataMember]
        public string Option1Var1 { get; set; }
        [IgnoreDataMember]
        public override Options Option {get { return Options.Option1; } }
    }
    
    [DataContract]
    public class Option2 : BaseData
    {
        [DataMember]
        public string Option2Var1 { get; set; }
        [IgnoreDataMember]
        public override Options Option {get { return Options.Option2; } }
    }
