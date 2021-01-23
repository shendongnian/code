    private object globalLock = new object();
    private Dictionary<int, object> lockObjects = new Dictionary<int, object>();
    public void listView_DoubleClick(object sender, EventArgs e) 
    {
        lock (globalLock)
        {
            if (!lockObjects.ContainsKey(1))
                lockObjects.Add(1, new object());
        }
        lock (lockObjects[1])
        {
            func1();
        }
    }
