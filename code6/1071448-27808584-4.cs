    public bool GetBoolean(string name)
    {
        return this.GetBoolean(this.GetOrdinal(name));
    }
    public override bool GetBoolean(int i)
    {
        return Convert.ToBoolean(this.GetValue(i));
    }
