        [Serializable]
        [ProtoContract]
        [DataContract]
        public class ModelADict
        {
            [ProtoMember(1)]
            [DataMember]
            public Dictionary<string, ModelA> sub { get; set; }
    
            public ModelADict()
            {
                sub = new Dictionary<string, ModelA>();
            }
        }
