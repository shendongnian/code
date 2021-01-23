    public partial class License
    {     
        public int LicenseId { get; set; }
        [NotMapped]
        public LicenseTypes Licensetype { get; set;{ _default = value; } }
    }
