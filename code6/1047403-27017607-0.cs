    protected IEnumerable<StudentAddress> addresses;
    public virtual IEnumerable<StudentAddress> Address
    {
        get { return addresses; }
        set
        {
            addresses = value == null ? null : value.OrderBy(a => a.Id);
        }
    }
