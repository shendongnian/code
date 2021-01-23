    [DataContract]
    class MyData {
        // Old member
        // public Translations Translations { get; set; }
        public List<Translation> Translations { get; set; }
        [DataMember]
        public string ThisShouldBeSerialized { get; set; }
    }
