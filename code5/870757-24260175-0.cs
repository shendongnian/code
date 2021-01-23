    public int Id { get; set; }
    [Index("IX_FirstNameLastName", 1, IsUnique = true)]
    public string FirstName { get; set; }
    [Index("IX_FirstNameLastName", 2, IsUnique = true)]
    public string LastName { get; set; }
