        public static IEnumerable<IEnumerable<T>> ToInMemoryBatches<T>(this IEnumerable<T> source, int batchSize)
        {
            List<T> batch = null;
            foreach (var item in source)
            {
                if (batch == null)
                    batch = new List<T>();
                batch.Add(item);
                if (batch.Count != batchSize)
                    continue;
                yield return batch;
                batch = null;
            }
            if (batch != null)
                yield return batch;
        }
