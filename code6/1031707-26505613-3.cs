    private object globalLock = new object();
    private Dictionary<int, object> lockObjects = new Dictionary<int, object>();
    public void listView_DoubleClick(object sender, EventArgs e) 
    {
        object lockObject;
        lock (globalLock) // to avoid two threads creating the object
        {
            if (!lockObjects.ContainsKey(1))
                lockObjects.Add(1, new object());
            lockObject = lockObjects[1];
        }
        if (Monitor.TryEnter(lockObject) // enter only if no thread has already entered
        {
            try { func1(); }
            finally { Monitor.Exit(lockObject); }
        }
    }
