    public byte JustForMappingCtryId{ get; set; }
    [NotMapped]
    public int CountryId
    { 
    get
      { 
        return Convert.ToInt32(this.JustForMappingCtryId);
      } 
    set
      {
        if(value > 8 || value < 0 )
        {
          throw new ArgumentOutOfRangeException("Must be 8 or less, and greater or equal to zero.");
        }
        //this.JustForMappingCtryId = value;  /* Do a conversion here */
      } 
    }
