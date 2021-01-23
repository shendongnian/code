    [NotMapped]
    public double Longitude
    {
      get
      {
        return this.FromNullable(this.longitude);
      }
      set
      {
        this.PropertyChange(ref this.longitude, value);
      }
    }
   
    [Column("Longitude")]
    public double? LongitudeStored
    {
      get
      {
        return this.longitude;
      }
      set
      {
        this.PropertyChange(ref this.longitude, value);
      }
    }
