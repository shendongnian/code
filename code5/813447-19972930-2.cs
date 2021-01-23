    public void Serialize(StringWriter sw_)
    {
        if (typeof (T) == typeof (Guid))
        {
            ((Guid)(object)value).Serialize(sw_);
        }
    }
