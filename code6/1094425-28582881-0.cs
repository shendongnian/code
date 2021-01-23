    public class UserForms
    {
        public int Id { get; set; }
        public string FullNames { get; set; }
        public int IndividualsCountryId { get; set; }
        [ForeignKey("IndividualsCountryId")]
        public virtual Countries IndividualsCountry { get; set; }
        public int BusinessCountryId { get; set; }
        [ForeignKey("BusinessCountryId")]
        public virtual Countries BusinessCountry { get; set; }
    }
