    // in your controller...
    private IRequestInformation _request;
    public IRequestInformation RequestInfo
    {
        get
        {
            if (_request == null)
                _request = new RequestInformation();
            return _request;
        }
        set { _request = value; }
    }
