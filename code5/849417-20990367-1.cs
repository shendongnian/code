    [DataContract]
    public class Time
    {
        [DataMember(Name="time", EmitDefaultValue = false)]
        public string Time
        {
            get;
            set;
        }
        [DataMember(Name = "holes", EmitDefaultValue = false)]
        public int Holes
        {
            get;
            set;
        }
        [DataMember(Name = "slots_available", EmitDefaultValue = false)]
        public int Slots_available
        {
            get;
            set;
        }
        [DataMember(Name = "price", EmitDefaultValue = false)]
        public decimal? Price
        {
            get;
            set;
        }
        [DataMember(Name = "nextcourseid", EmitDefaultValue = false)]
        public int? Nextcourseid
        {
            get;
            set;
        }
        [DataMember(Name = "allow_extra", EmitDefaultValue = false)]
        public bool? Allow_extra
        {
            get;
            set;
        }
    }
