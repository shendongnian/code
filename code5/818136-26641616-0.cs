    public MyObject
    {
       .. other properties
       [MaxLength(128), ForeignKey("ApplicationUser")]
       public virtual string UserId { get; set; }
    
       public virtual ApplicationUser ApplicationUser { get; set;}
    }
