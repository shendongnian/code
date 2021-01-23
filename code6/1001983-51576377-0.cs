    public int Id { get; set; }
    public string Email { get; set; }
    [JsonIgnore]
    public string Password { get; set; } // <--- Removed from JSON response
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public bool Active { get; set; }
