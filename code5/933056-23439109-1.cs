    public int PermissionId { get; set; }
    public int ParentId { get; set; }
    [DefaultValue(true)]
    public bool IsRequired { get; set; }
    public virtual Permission Permission { get; set; }
