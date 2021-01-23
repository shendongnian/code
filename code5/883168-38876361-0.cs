    public static T[] ToArray<T>(this IEnumerable<T> source)
        {
            int length = System.Linq.Enumerable.Count(source);
            T[] newArray = new T[length];
            int i = 0;
            foreach(T item in source)
            {
                newArray[i] = item;
            }
            return newArray;
        }
