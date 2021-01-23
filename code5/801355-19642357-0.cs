    public static int[] Process(params int[][] values)
    {
        int[] result = values[0];
    
        foreach (int[] value in values)
        {
            result = result.Intersect(value).ToArray();
        }
    
        return result;
    }
