    [DataContract]
    public class CounterpartyFrequency : EntityBase
    {
        [DataMember]
        [Key]
        public int CounterpartyFrequencyId { get; set; }
        [DataMember]
        public string LegalEntityId { get; set; }
        [ForeignKey("LegalEntityId")]
        public virtual LegalEntity LegalEntity { get; set; }
   }
