    public byte JustForMappingCtryId{ get; set; }
    public int CountryId
    { 
    get
      { 
        return Convert.ToInt32(this.JustForMappingCtryId);
      } 
    set
      {
        throw new NotImplementedException();
      } 
    }
