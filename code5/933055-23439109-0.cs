    [Key]
    public int Id { get; set; }
    
    [Required, StringLength(150)]
    public string Title { get; set; }
    
    public virtual List<PermissionDependency> Dependencies { get; set; }
