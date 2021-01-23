    public String Value
    {
        get { return this.value; }
        set
        {
            this.Add(x => this.Value = value);
            this.value = value;
        }
    }
