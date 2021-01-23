    public int CompanyID { get; set; }
    
        [Required]
        [StringLength(75, ErrorMessage = "Company Name cannot exceed 75 characters")]
        public string Name { get; set; }
    
        // Snip...
        //Address is the navigation property in Company, Address1 is the desired property from Address
        public string AddressAddress1 { get; set; }
        public string AddressAddress2 { get; set; }
        public string AddressCity { get; set; }
        public string AddressPostalCode { get; set; }
    }
