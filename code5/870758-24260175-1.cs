    public int Id { get; set; }
    [Index("IX_FirstNameLastName", 1, IsUnique = true, MaxLenght(128))]
    public string FirstName { get; set; }
    [Index("IX_FirstNameLastName", 2, IsUnique = true, MaxLenght(128))]
    public string LastName { get; set; }
