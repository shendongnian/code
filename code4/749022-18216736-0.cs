    [DataContract]
    public class Paradigm
    {
        [DataMember(Order = 1)]
        public string genitive;
        [DataMember(Order = 2)]
        public string dative;
        [DataMember(Order = 3)]
        public string accusative;
        [DataMember(Order = 4)]
        public string instrumental;
        [DataMember(Order = 5)]
        public string prepositional;
    }
