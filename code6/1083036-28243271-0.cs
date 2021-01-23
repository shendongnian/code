    [DataContract]
    public class Something {
        [DataMember]
        public string Stuff {get;set;}
        [DataMember(IsRequired=true)] // just this 1 simple change!
        public Status MyStatus {get;set;}
        public string ServerSideField {get;set;}
    }
