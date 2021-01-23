    [DataContract]
    public class BaseClass
    {
        [DataMember]
        public string Name { get; set; }
    }
    [Serializable]
    public class ChildClass: BaseClass
    {
        public string SecondName { get; set; }
        public int Age { get;set; }
    }
