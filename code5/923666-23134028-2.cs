    public static int IndexOf<T>(T[] array, T value, int startIndex, int count)
    {
        if (array == null)
        {
            throw new ArgumentNullException("array");
        }
        if (startIndex < 0 || startIndex > array.Length)
        {
            throw new ArgumentOutOfRangeException("startIndex", Environment.GetResourceString("ArgumentOutOfRange_Index"));
        }
        if (count < 0 || count > array.Length - startIndex)
        {
            throw new ArgumentOutOfRangeException("count", Environment.GetResourceString("ArgumentOutOfRange_Count"));
        }
        Contract.Ensures(Contract.Result<int>() < array.Length);
        Contract.EndContractBlock();
        return EqualityComparer<T>.Default.IndexOf(array, value, startIndex, count);
    }
