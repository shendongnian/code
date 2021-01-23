    private static string Trim(string value)
    {
        return String.IsNullOrEmpty(value)
               ? String.Empty
               : value.Trim();
    }
    private string _Name;
    public string Name
    {
        get { return _Name; }
        set { _Name = Trim(value); }
    }
        
