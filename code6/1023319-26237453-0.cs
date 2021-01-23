    private object GetPropertyValue(Style style, string propertyName)
    {
        foreach (Setter s in style.Setters)
        {
            if (s.Property.Name == propertyName)
            {
                return s.Value;
            }
        }
        if (style.BasedOn != null)
        {
            return GetPropertyValue(style.BasedOn, propertyName);
        }
        return null;
    }
