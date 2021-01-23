    public static class BatchOperations
    {
        public static IEnumerable<List<T>> Batch<T>(this List<T> items, int batchCount)
        {
            int totalSize = items.Count;
            int remain = totalSize % batchCount;
            int skip = 0;
            for (int i = 0; i < batchCount; i++)
            {
                int size = totalSize / batchCount + (i <= remain ? 1 : 0);
                if (skip + size > items.Count) yield return new List<T>(0);
                else yield return items.GetRange(skip, size);
                skip += size;
            }
        }
    
        public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> items, int batchCount)
        {
            int totalSize = items.Count();
            int remain = totalSize%batchCount;
            int skip = 0;
            for (int i = 0; i < batchCount; i++)
            {
                int size = totalSize/batchCount + (i <= remain ? 1 : 0);
                yield return items.Skip(skip).Take(size);
                skip += size;
            }
        }
    }
