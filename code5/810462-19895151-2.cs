    public void BubbleSort<T>(T[] array) where T: IComparable<T>
    {
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 1; j < array.Length; j++)
            {
                if (array[j].CompareTo(array[j-1]) < 0)
                {
                }
            }
        }
    }
