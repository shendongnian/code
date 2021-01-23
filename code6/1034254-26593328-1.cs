    public int[] RemoveDuplicates(int[] source)
    {
        bool occurredOnce = true;
        int currentItem = source[0];
    
        var result = new List<int>();
    
        for (int i = 1; i < source.Length; i++)
        {
            if (source[i] != currentItem)
            {
                if (occurredOnce)
                {
                    result.Add(currentItem);
                }
    
                currentItem = source[i];
                occurredOnce = true;
            }
            else 
            {
                occurredOnce = false;
            }
        }
    
        if (occurredOnce)
        {
            result.Add(currentItem);
        }
    
        return result.ToArray();
    }
