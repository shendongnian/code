    [DataContract]
    public class BaseClass
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string SecondName { get; set; }
    }
    [DataContract]
    public class ChildClass : BaseClass
    {
        //[DataMember]
        //public string SecondName { get; set; }
        [DataMember]
        public int Age {get;set;}
    }
