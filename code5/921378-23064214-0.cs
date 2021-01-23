    Dictionary<string, Delegate>() _delegates;
    
    void Test1(int a) { }
    void Test2(int a, int b) { }
    
    void SetUp() {
        _delegates = new Dictionary<string, Delegate>();
        _delegates.Add("test1", Test1);
        _delegates.Add("test2", Test2);
    }
    
    void CallIt(string name, params object[] args) {
        _delegates[name].DynamicInvoke(args);
    }
