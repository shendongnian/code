    public string FirstPersonName { get; set; }
    public string LocationName { get; set; }
    
    public string PropertyEvidenceBL
    {
        get {
            return !string.IsNullOrEmpty(FirstPersonName) ? FirstPersonName : LocationName;
        }
    }
