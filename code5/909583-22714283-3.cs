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
            //this.JustForMappingCtryId = value;  /* Uncomment this code.. to put back the setter... you'll have to do the conversion here (from the input int to the byte) of course..but the edited out code shows the intention */      
        }
    }
