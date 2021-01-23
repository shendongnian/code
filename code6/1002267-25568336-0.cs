    public test()
    {
        _isTesting = false;
    }
    private bool _isTesting;
    public bool isTesting {
        private set { _isTesting = value; }
        get { return _isTesting; }
    }
