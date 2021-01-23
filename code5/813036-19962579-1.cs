    protected void FindPrimaryKey()
    {
        var prop = this.GetType()
                       .GetProperties()
                       .Where(p => Attribute.IsDefined(p, typeof(Key)))
        if (prop != null) { _keyValue = prop.GetValue(this); }
    }
