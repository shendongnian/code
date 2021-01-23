    void Main()
    {
        object dummy = new object();
        Action a = delegate
        {
            if (dummy != null)
                Debug.WriteLine("not null");
            else
                Debug.WriteLine("null");
        };
    
        a();
        dummy = null;
        a();
    }
