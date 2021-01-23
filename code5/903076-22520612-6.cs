    public static int[] ConvertToBase(BigInteger value, int newBase, int length)
    {
        var result = new Stack<int>();
    
        while (value > 0)
        {
            result.Push((int)(value % newBase));
            if (value < newBase)
                value = 0;
            else
                value = value / newBase;
        }
    
        for (var i = result.Count; i < length; i++)
            result.Push(0);
    
        return result.ToArray();
    }
