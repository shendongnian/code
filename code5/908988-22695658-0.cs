    public string Password { get; set; }
    public void SetPassword(string password) {
        //Password checks
        Password = Crypto.HashPassword(password);
    }
