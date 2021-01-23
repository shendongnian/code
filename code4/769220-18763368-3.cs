    [DataContract(Name = "One", Namespace = "")]
    [KnownType(typeof(List<Two>))]
    public sealed class One
    {
        public One()
        {
            ListOfTwo = new List<Two>();
        }
        [OnDeserialized]
        internal void OnSerializingMethod(StreamingContext context)
        {
            if (ListOfTwo == null)
            {
                ListOfTwo = new List<Two>();
            }
        }
        [DataMember]
        public List<Two> ListOfTwo { get; set; }
    }
