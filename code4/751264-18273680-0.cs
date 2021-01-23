    // the dictionary
    static Dictionary<string, string> _events = new Dictionary<string, string>();
    // public boolean
    static bool isIdle = true;
    // metod that a thread calls
    bool doSomthingToDictionary()
    {
        // if another thread is using this method do nothing,
        // just return false. (the thread will get false and try another time!)
        if (!isIdle) return false;
        // if it is Idle then:
        isIdle = false;
        ResetDictionary(); // do anything to your dictionary here
        isIdle = true;
        return true;
    }
