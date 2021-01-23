    [StringLength(65)]
    [Index("IX_FirstNameLastName", 1, IsUnique = true)]
    public string FirstName { get; set; }
    [StringLength(65)]
    [Index("IX_FirstNameLastName", 2, IsUnique = true)]
    public string LastName { get; set; }
