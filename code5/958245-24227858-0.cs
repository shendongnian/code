    protected T GetVariable<T>(string key)
    {
        string result;
        this.Character.Variables.TryGetValue(key, out result);
        if (result != null)
        {
            return Convert.ChangeType(result, typeof(T));
        }
        else
        {
            return default(T);
        }
    }
