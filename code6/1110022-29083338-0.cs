    public static T[] Join<T>(T separator, IEnumerable<T[]> arrays)
    {
        // Make sure we only iterate over arrays once
        List<T[]> list = arrays.ToList();
        if (list.Count == 0)
        {
            return new T[0];
        }
        int size = list.Sum(x => x.Length) + list.Count - 1;
        T[] ret = new T[size];
        int index = 0;
        bool first = true;
        foreach (T[] array in list)
        {
            if (!first)
            {
                ret[index++] = separator;
            }
            Array.Copy(array, 0, ret, index, array.Length);
            index += array.Length;
            first = false;
        }
        return ret;
    }
