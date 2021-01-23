    public string Category1
    {
        get
        {
            if (categories.Length < 1)
                return string.Empty;
            return categories[0];
        }
    }
