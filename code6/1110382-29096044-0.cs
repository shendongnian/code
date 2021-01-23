    void Add(object item)
    {
        int requiredSpace = Count + 1;
        if (buffer.Length < requiredSpace)
        {
            // increase underlying buffer
        }
        buffer[Count] = item;
    }
    
