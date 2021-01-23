    public Employee 
    {
        public string EmployeeId { get;set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<LicenseRegistration> RegisteredLicenses { get; set; }
    }
    public LicenseType
    {
       public int StateLicenseTypeId { get; set; }
       public string State { get; set; }
       public string LicenseName { get; set; } 
       public virtual ICollection<LicenseRegistration> RegisteredLicenses { get; set; }
    }
    public LicenseRegistration
    {
       //properties for the additional information go here
       /////////////////////////////////////////////////////
     
       public int EmployeeId {get;set;}
       [ForeignKey("EmployeeId")]
       public Employee Employee {get;set;}
       public int LicenseTypeId {get;set;}
       [ForeignKey("LicenseTypeId")]
       public LicenseType {get;set;}
    }
