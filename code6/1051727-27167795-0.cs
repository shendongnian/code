    [DataMember]
    [Required(ErrorMessage="Customer name cannot be empty.")]
    public string Forename
    {
        get 
        { 
            return forename;
        }
        set
        {
            Validator.ValidateProperty(value, 
                new ValidationContext(this, null, null) { MemberName = "Forename" });
            forename = value;
            NotifyPropertyChanged("Forename");
        }
    }
