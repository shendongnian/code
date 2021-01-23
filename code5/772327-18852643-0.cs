    private IList<PName> _property = new IList<PName>();
    public ReadOnlyCollection<PName> Property
    {
        get
        {
            if (_property!= null)
            {
                return new ReadOnlyCollection<PName>(new List<PName>(this._property));
            }
        }
    }
