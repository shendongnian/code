    [InverseProperty("Person")]
    public virtual List<Hobbies> Hobbies {get;set;}
    
    [NotMapped]
    public List<Sport> Sports 
    {
        get
        {
            return this.Hobbies.OfType<Sport>().ToList();
        }
    }
    
    
    [NotMapped]
    public List<Art> Art 
    {
        get
        {
            return this.Hobbies.OfType<Art>().ToList();
        }
    }
    
    
    [NotMapped]
    public List<Reading> Readings 
    {
        get
        {
            return this.Hobbies.OfType<Reading>().ToList();
        }
    }
