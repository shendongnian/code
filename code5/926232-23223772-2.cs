    set
    {
        if (0 >= value.Length)
        {
            MyObject = null;
            return;
        }
    
        IFormatter formatter = new BinaryFormatter();
        using (var ms = new MemoryStream(value))
        {
            MyObject = formatter.Deserialize(ms);
        }
        
        return;
    }
