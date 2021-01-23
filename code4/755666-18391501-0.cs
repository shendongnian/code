    private string _pinMessafe;
    object locker = new object();
    public string pinmesssage
    {
        get
        {
            string x = null;
            while(x == null) {
              lock(locker) { x = _pinMessafe ; }
              Thread.Sleep(1);
            }
            return x;
        }
        set { lock(locker) { _pinMessafe = value; } }
    }
