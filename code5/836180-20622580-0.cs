    public string RegistrationStatus { get; set; }
    
    [NotMapped]
    public RegistrationStatus EnumStatus
    {
      get { return (RegistrationStatus) Enum.Parse(typeof(RegistrationStatus), this.RegistrationStatus); }
      set { this.RegistrationStatus = value.ToString();
    }
