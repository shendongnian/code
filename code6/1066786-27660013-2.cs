    private string _username;
    [Required]
    [MaxLength(50)]
    public String UserName  // This is where I am using encryption decryption methods
    { 
        set
        {
            _username = NewEncryptionMethod(value);
        }
        get
        {
           //you have to deal with a null username here is a bad but quick solution
           _username = _username ?? string.Empty;
            return NewDecryptionMethod(_username);
        } 
    }
