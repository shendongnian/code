    public long MovieId { get; set; }
    [Required]
    [StringLength(100)]
    public string name { get; set; }
    [ForeignKey("Owner")]
    public string OwnerID { get; set; }
    public virtual ApplicationUser Owner {set;get;}
    }
