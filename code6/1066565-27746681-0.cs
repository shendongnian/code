    private void VerifyCaller(Assembly a)
    {
        if (a == Assembly.GetExecutingAssembly()) { return; }
        
        var name = a.GetName();
        if(name.Name == "AppA" && name.GetPublicKey() == appAPublicKey) { return; }
        throw new InvalidOperationException("You can't access this");
    }
    private string _serialNumber;
    public string SerialNumber
    {
        get { return _serialNumber; }
        set
        {
            VerifyCaller(Assembly.GetCallingAssembly());
            _serialNumber = value;
        }
    }
