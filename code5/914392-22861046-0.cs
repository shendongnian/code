    //Primary key
    public string ID { get; set; } 
    //Foreign key
    public int? LogotypeID { get; set; }
    public virtual Logotype Logotype {get;set;}
