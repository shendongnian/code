    public bool ReadOnly
    {
        get
        {
            return this.GetStatus(Load.Date);
        }
    }
