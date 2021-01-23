    private int _minRequiredPasswordLength;
    public override void Initialize(string name, NameValueCollection config)
    {
        _minRequiredPasswordLength = // get it from config["minRequiredPasswordLength"], with validation and conversion to int.
    }
    public override MinRequiredPasswordLength
    {
        get { return _minRequiredPasswordLength; }
    }
