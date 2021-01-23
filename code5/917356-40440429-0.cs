    public void Start()
    {
        Invoke(
            methodName : GetMethodName((System.Action)Explode), 
            time: 1f);
    
        Invoke(
            methodName : GetMethodName((System.Action<int>)HandleMyNumber), 
            time: 2f);
    }
    
    public static string GetMethodName(System.Delegate @delegate)
    {
        return @delegate.Method.Name;
    }
    
    private void Explode()
    {
        // Do something Action like...   
    }
    
    private void HandleMyNumber(int number)
    {
        // Do something Action<int> like...
    }
