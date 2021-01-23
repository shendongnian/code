    public class UserForms
        {
            public int Id { get; set; }
    
            public string FullNames { get; set; }
    	[ForeignKey("IndividualsCountry")]
            public int? IndividualsCountryId { get; set; }
    	[ForeignKey("BusinessCountry")]
            public int? BusinessCountryId { get; set; }
    
            public virtual Countries IndividualsCountry { get; set; }
    	public virtual Countries BusinessCountry { get; set; }
        }
    
    public class Countries
        {
            public Countries()
            {
                this.STRBusinessCountry = new HashSet<UserForms>();
                this.STRIndividualsCountry = new HashSet<UserForms>();
            }
           
            public int Id { get; set; }
            public string NameOfCountry { get; set; }
    
            [InverseProperty("IndividualsCountry")]
            public virtual ICollection<UserForms> STRIndividualsCountry { get; set; }
            [InverseProperty("BusinessCountry")]
            public virtual ICollection<UserForms> STRBusinessCountry { get; set; }
        }
