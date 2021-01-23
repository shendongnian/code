    private static Array ResizeArray(Array arr, int[] newSizes)
    {
        // Add next four lines
        if (newSizes == null)
            throw new ArgumentNullException("newSizes is null!"); 
        if (arr == null)
            throw new ArgumentNullException("arr is null!"); 
        if (newSizes.Length != arr.Rank)
            throw new ArgumentException("arr must have the same number of dimensions " +
                                        "as there are elements in newSizes", "newSizes");
    
        var temp = Array.CreateInstance(arr.GetType().GetElementType(), newSizes);
        int length = arr.Length <= temp.Length ? arr.Length : temp.Length;
        Array.ConstrainedCopy(arr, 0, temp, 0, length);
        return temp;
    }
