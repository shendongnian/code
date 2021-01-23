    private bool hasDefaultValue = false;
    [XmlAttributeAttribute("Name")]
    public string Name;
    [XmlAttribute("SaveOnClose")]
    public bool SaveOnClose;
    [XmlIgnore]
    public bool SaveOnCloseSpecified
    {
        get { return hasDefaultValue; }
    }
    public UserPreferences() { }
    public UserPreferences(string Name)
    {
        this.Name = Name;
    }
    public UserPreferences(string Name, bool SaveOnClose)
    {
        this.Name = Name;
        this.SaveOnClose = SaveOnClose;
        hasDefaultValue = true;
    }
