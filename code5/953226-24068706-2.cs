    public static int BinarySearch<T>(
        this  IList<T> collection, T item, IComparer<T> comparer = null)
    {
        comparer = comparer ?? Comparer<T>.Default;
        int startIndex = 0;
        int endIndex = collection.Count;
        while (startIndex <= endIndex)
        {
            int testIndex = startIndex + ((endIndex - startIndex) / 2);
            if (testIndex == collection.Count)
                return testIndex;
            int comparision = comparer.Compare(collection[testIndex], item);
            if (comparision > 0)
            {
                endIndex = testIndex - 1;
            }
            else if (comparision == 0)
            {
                return testIndex;
            }
            else
            {
                startIndex = testIndex + 1;
            }
        }
        return startIndex;
    }
