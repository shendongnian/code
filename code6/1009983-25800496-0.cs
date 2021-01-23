    private string _title;
    public string Title
    {
        get { return _title; }
        set
        {
            if (!String.IsNullOrWhiteSpace(value) && _title != value)
            {
                _title = value;
            }
        }
    }
