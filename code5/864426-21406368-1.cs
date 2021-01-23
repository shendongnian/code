    [Column("UserType")]
    public int UserTypeValue { get; set; }
    
    [NotMapped]
    public UserType Type
    {
      get { return (UserType) UserTypeValue;
      set { UserTypeValue = (int)value;
    }
