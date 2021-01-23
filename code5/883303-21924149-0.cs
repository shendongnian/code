    public T GetDefaultIfNull<T>(Func<T> funcToInvoke, T defaultValue)
    {
        T result;
        try
        {
            result = stringFunc.Invoke();
            if (result == null)
            {
                 //Do something with result as it is not null
            }
            else{
                result = defaultValue;
            }
        }
        catch (Exception ex)
        {
            ex.Message;
        }
        return result;
    }
