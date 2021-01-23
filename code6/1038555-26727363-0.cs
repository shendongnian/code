    public object this[string key]
    {
        get
        {
            var pi = this.GetType().GetProperty(key); // find the property that matches the key
            return pi.GetValue(this, null);
        }
        set
        {
            var pi = this.GetType().GetProperty(key); // find the property that matches the key
            pi.SetValue(this, value, null);
        }
    }
