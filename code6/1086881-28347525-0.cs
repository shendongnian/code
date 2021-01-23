    [Required]
    public bool Saturday{ get; set; }
    [Required]
    public bool Sunday{ get; set; }
    [NotMapped]
    public bool SatSun
    {
        get
        {
            return (!this.Saturday && !this.Sunday);
        }
    }
    [RequiredIf("SatSun",true)]
    public string Holiday{ get; set; }
