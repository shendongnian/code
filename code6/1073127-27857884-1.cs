    public void AddData(string key, object val)
    {
        // Use the new overload, passing null for the third parameter.
        AddData(key, object, null);
    }
    public void AddData(string key, object val, string region)
    {
        // etc
        if (region != null)
        {
            // etc
        }
        // etc
    }
