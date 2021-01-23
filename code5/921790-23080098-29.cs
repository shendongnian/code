    [DataContract]
    public class BaseClass
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string SecondName { get; set; }
        
    }
    [Serializable]
    public class ChildClass: BaseClass
    {
        
        public int Age { get;set; }
    }
