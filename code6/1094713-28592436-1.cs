    public string ExternalName
    {
        get { return Name; }
        set
        {
            string cleanName = clsStringManip.CleanText(value, true);
            if (cleanName != Name)
            {
                Name = cleanName;
            }
        }
    }
