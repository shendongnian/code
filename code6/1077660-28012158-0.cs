    public static int[] neighbourbets2(int x, int neighborCount)
    {
        int[] pocket_array = new[] { 0, 32, 15, 19, 4, 21, 2, 25, 17, 34, 6, 27, 13, 36, 11, 30, 8, 23, 10, 5, 24, 16, 33, 1, 20, 14, 31, 9, 22, 18, 29, 7, 28, 12, 35, 3, 26 };
        int predictednum = Array.IndexOf(pocket_array, x);
    
        // Initialize the result array. Its size is double the neighbour count + 1 for x
        int[] result = new int[neighborCount * 2 + 1];
    
        // Calc the start index. We begin at the most left item.
        int startAt = predictednum - neighborCount;
        // i - position in the result array
        // j - position in the pocket_array
        for (int i = 0, j = startAt; i < result.Length; i++, j++)
        {
            // Adjust j if it's less then 0 to wrap around the array.
            result[i] = pocket_array[j < 0 ? j + pocket_array.Length : j];
            // If we are at the end then start from the beginning.
            if (j == pocket_array.Length)
            {        
                j = 0;
            }
        }
        return result;
    }
