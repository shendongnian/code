    [JsonObject(IsReference = true)]
    [DataContract(IsReference = true)]
    public class Parent : TrackableEntityBase
    {
        [DataMember]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ParentId
        {
            get { return base.Id ; }
            set
            {
                if (base.Id.Equals(default(Guid)))
                    base.Id = value;
                if (base.Id.Equals(value))
                    return;
                throw new InvalidOperationException("Primary Keys cannot be changed once set.");
            }
        }
        [DataMember]
        public String Name 
        {
            get { return _name; }
            set
            {
                if (!String.IsNullOrWhiteSpace(_name) && _name.Equals(value, StringComparison.Ordinal))
                {
                    return;
                }
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        String _name;
        [DataMember]
        [JsonConverter(typeof(TrackableCollectionConverter<Child, TrackableCollectionCollection<Child>>))]
        public virtual TrackableCollectionCollection<Child> Children { get; set; }
    }
