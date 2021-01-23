    public static bool IsSorted(int[] array, int n)
    {
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i - 1] > array[i])
            {
                return false;
            }
        }
        return true;
    }
