    public virtual IList<Address> Addresses { get; set; }; 
    public virtual IList<Phone> Phones { get; set; };
    
    public CLASS()
    {
        Addresses = new List<Address>();
        Phones = new List<Phone>()
    }
