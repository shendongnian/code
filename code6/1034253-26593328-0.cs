    public int[] RemoveDuplicates(int[] source)
    {
        int itemCount = 1;
        int currentItem = source[0];
        
        var result = new List<int>();
        
        for (int i = 1; i < source.Length; i++)
        {
            if (source[i] != currentItem)
            {
                if (itemCount == 1)
                {
                    result.Add(currentItem);
                }
                
                currentItem = source[i];
                itemCount = 1;
            }
            else 
            {
                itemCount++;
            }
        }
        
        if (itemCount == 1)
        {
            result.Add(currentItem);
        }
        
        return result.ToArray();
    }
