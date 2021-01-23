    public object this[string name]
    {
        get
        {
            object result;
            if (Dictionary.TryGetValue(name, out result))
            {
                if (result is DBNull)
                {
                    result = null;
                }
                else if (result is byte && Meta.IsBool(this.Table, name))
                {
                    result = (byte) result > 0;
                }
            }
            return result;
        }
        set
        {
            // TODO: Byte/bool conversions?
            if (value is DateTime)
            {
                // Note use of invariant culture here. You almost certainly
                // want this, given the format you're using. Preferably,
                // avoid the string conversions entirely, but...
                DateTime dateTime = (DateTime) value;
                if (Meta.IsDate(this.Table, name))
                {
                    value = dateTime.ToString(CultureInfo.InvariantCulture, "yyyy-MM-dd");
                }
                else if (Meta.IsDateTime(this.Table, name))
                {
                    value = dateTime.ToString(CultureInfo.InvariantCulture, "yyyy-MM-dd HH:mm:ss");
                }
            }
            Dictionary[name] = value;
        }
    }
