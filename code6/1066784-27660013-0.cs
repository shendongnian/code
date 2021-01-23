    [Required]
    [MaxLength(50)]
    public String UserName  // This is where I am using encryption decryption methods
    { 
        set
        {
            //this.UserName will call the propertyname again and again it's a infinite recursive loop
            this.UserName = NewEncryptionMethod(value);     
        }
        get
        {
            //same here infinite recursive loop
            return NewDecryptionMethod(this.UserName);
        } 
    }
