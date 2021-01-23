    [XmlElement("password")]
    public string Password { get; set; }
    
    [XmlElement("password_confirmation")]
    public string PasswordConfirmation{ get { return Password;} set; }
