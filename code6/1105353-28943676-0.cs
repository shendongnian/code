    private void AddVariable<T>(String name, T value) 
    {
        // common code here
    }
    
    public void AddVariable(String name, int value) 
    {
        AddVariable<int>(name, value);
    }
    
    public void AddVariable(String name, string value) 
    {
        AddVariable<string>(name, value);
    }
