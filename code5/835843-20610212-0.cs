    public string ColorName(Color toCheck)
    {
        string result = "";
        foreach (KnownColor known in Enum.GetValues(typeof(KnownColor)))
        {
                Color c = Color.FromKnownColor(kc);
                if (toCheck.ToArgb() == known.ToArgb())
                {
                    result = known.Name;
                }
        }
    
        return result;
    }
