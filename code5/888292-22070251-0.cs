    public T YourMethod<T>(Func<T> functionParam)
    {
       return (T)functionParam.Invoke();
    }
    public bool YourFunction(string foo, string bar, int intTest)
    {
        return true;
    }
