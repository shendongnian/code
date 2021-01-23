    private Hashtable _ht = new Hashtable();
    private bool _isLoaded = false;
    private object lockObj = new object();
    
    internal Hashtable GetHT()
    {
        if (_isLoaded == false)
        {
             lock (lockObj)
             {
                 if (_isLoaded == false)
                 {
                     LoadHt(_ht);
                 }
             }
         }
    
         return _ht;
    }
