    public const string FirstNamePropertyName = "FirstName";
    private string firstName = string.Empty;
    public string FirstName 
    {
        get { return firstName; }
    	set { this.ChangeAndNotify(ref this.firstName, value, FirstNamePropertyName); }
    } 
