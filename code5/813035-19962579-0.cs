    protected object FindPrimaryKey()
    {
        object key = null;
        var prop = this.GetType()
                       .GetProperties()
                       .Where(p => Attribute.IsDefined(p, typeof(Key)))
        if (prop != null) { key = prop.GetValue(this); }
        return key;
    }
