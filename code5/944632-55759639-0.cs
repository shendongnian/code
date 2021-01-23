    [Key]
    public string Id { get; set; }
    public your_constructor()
    {
        Id = Guid.NewGuid().ToString();
    }
