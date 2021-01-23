    public static class Helper
    {
        public static IEnumerable<IEnumerable<T>> StrangePartition<T>(this IEnumerable<T> source, T partitionKey)
        {
            List<List<T>> partitions = new List<List<T>>();
            List<T> partition = new List<T>();
            foreach (T item in source)
            {
                if (item.Equals(partitionKey))
                {
                    partitions.Add(partition);
                    partition = new List<T>();
                }
                else
                {
                    partition.Add(item);
                }
            }
            partitions.Add(partition);
            return partitions;
        }
    }
