    [Required]
    public Guid TenantId { get; set; }
 
    [ForeignKey("TenantId")]
    public virtual Tenant Tenant { get; set; }
