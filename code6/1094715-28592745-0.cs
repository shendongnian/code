    private string _name = "";
    public string Name
    {
        get { return _name; }
        set
        {
            string cleanName = value;
            Cleanup_Name(ref cleanName);
            if (cleanName != _name)
            {
                _name = cleanName;
            }
        }
    }
    private partial void Cleanup_Name(ref string);
