    [DataContract]
    public class Conference
    {
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string datetime { get; set; }
        [DataMember]
        public string updateDateTime { get; set; }
        [DataMember]
        public int duration { get; set; }
        [DataMember]
        public string description { get; set; }
        [IgnoreDataMember]
        private bool _isEditDeleteVisible;
    }
    [DataContract]
    public class ConferenceModel
    {
        [DataMember]
        public List<Conference> conferences { get; set; }
    }
