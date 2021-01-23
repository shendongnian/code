    private static ISingletonClass _instance = null;
    private static readonly object _lock = new object();
    public static ISingletonClass GetInstance(string id = null)
    {
        lock (_object)
        {
            if (_instance == null || (id != null && _instance.Id != id))
            {
                if (id == null)
                {
                    throw new ArgumentNullException("id");
                }
                _instance = new SingletonClass(id);
            }
            return _instance;
        }
    }
