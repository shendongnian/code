    private static Object thisLock = new Object();
    protected static RecRepository rep
    {
        get
        {
            lock ( thisLock ) {
                if (_rep == null)
                    _rep = new RecRepository();
            }
            return _rep;
        }
    }
