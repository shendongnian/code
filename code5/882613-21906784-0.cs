    public int CreatedBy_OperatorId { get; set; }
    
    [Display(Name = "Created By")]
    [ForeignKey("CreatedBy_OperatorId")]
    public virtual Operator CreatedBy { get; set; }
    
    public int ModifiedBy_OperatorId { get; set; }
    
    [Display(Name = "Created By")]
    [ForeignKey("ModifiedBy_OperatorId")]
    public virtual Operator ModifiedBy { get; set; }
