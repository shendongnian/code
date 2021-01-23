    Dictionary<string, string> list = new Dictionary<string, string>();
    object lockObj = new object();
    
    public void MyMethod(string a) {
    
        if (list.Contains(a))
            return;
    
        lock (lockObj) {
           if (!list.Contains(a)){
            list.Add(a,"someothervalue");
           }
        }
    }
