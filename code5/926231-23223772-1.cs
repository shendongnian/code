    set
    {
        if (value.Length > 0)
        {
            IFormatter formatter = new BinaryFormatter();
            using (var ms = new MemoryStream(value))
            {
                MyObject = formatter.Deserialize(ms);
            }
            
            return;
        }
    
        MyObject = null;
    }
