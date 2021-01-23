    public string FirstPersonName { get; set; }
    public string LocationName { get; set; }
    
    public string PersonOrLocationName {
        get {
            return !string.IsNullOrEmpty(FirstPersonName) ? FirstPersonName : LocationName;
        }
    }
    // From your post this looks like the class constructor...
    public PropertyEvidenceBL
    {
        // Do something with the name...
        string name = PersonOrLocationName;
    }
