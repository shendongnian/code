    public virtual new bool active
    {
        get { return active_field && (this.Expiration == null || this.Expiration < DateTime.Now); }
        set { active_field = value; }
    }
