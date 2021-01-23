    private string[] values;
    public string[] Values
    {
        get { return values; }
        set
        {
            if (this.values == value)
                return;
            this.values = value;
            this.ProcessStrings();
        }
    }
