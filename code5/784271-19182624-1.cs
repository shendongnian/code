    public override bool Equals(object obj)
    {
        if (!(obj is DrawingData))
        {
            return base.Equals(obj);
        }
        else
        {
            return this.DrawingName.Equals((obj as DrawingData).DrawingName, StringComparison.OrdinalIgnoreCase);
        }
    }
    public override int GetHashCode()
    {
        return DrawingName.GetHashCode();
    }
