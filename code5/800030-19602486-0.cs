    static ConcurrentDictionary<string, object> _locksByUser = new ConcurrentDictionary<string, object>();
    public void Save(string userId) {
       var lock = _locksByUser.GetOrAdd(userId, new object());
       if (Monitor.TryEnter(lock)) {
           try {
           //do save here
           }
           finally {
               Monitor.Exit(lock);
           }
       }
    }
