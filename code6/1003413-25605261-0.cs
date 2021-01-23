    public virtual bool Matches(InstrumentSpec otherSpec)
    {
        foreach (var prop in otherSpec.Properties.Keys)
        {
            if (!Object.equals(properties[prop], otherSpec[prop]))
            {
                return false;
            }
        }
        return true;
    }
