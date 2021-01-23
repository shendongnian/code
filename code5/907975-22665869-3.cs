    [DefaultValue("This is my default")]
    public string MyProperty
    {
        get
        {
            string value = this.db.getMyProperty();
            if (value == null)
            {
                value = GetDefaultValueForProperty();
            }
            return value;
        }
    }
