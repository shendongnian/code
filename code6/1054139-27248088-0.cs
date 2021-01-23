    public void UpdateDB<T>(T obj)
    {
        var properties = typeof(T).GetProperties();
    
        foreach (var prop in properties)
        {
            // Here you loop through the properties.
        }
    }
