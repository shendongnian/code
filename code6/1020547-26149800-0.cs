    public static List<T> SplitItems<T>(
            List<T> items,
            int totalPartitions,
            int partitionNumber)
        {
            var result = new List<T>();
            int partitionIndex = partitionNumber - 1;
            int size = (int)Math.Ceiling((double)items.Count / totalPartitions);
            result.AddRange(items.Skip(size * partitionIndex).Take(size));
            return result;
        }
