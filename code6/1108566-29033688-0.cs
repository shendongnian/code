    public class CompanyInfo
    {
        [Key]
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public Address CompanyAddress  { get; set; }
        [ForeignKey("CompanyAddress")]
        public string PrimaryStreetAddress  { get; set; }
    }
