        public static T[][] FillBucketsEvenly<T>(IEnumerable<T> items, int bucketCount)
        {
            int itemsPerBucket = items.Count() / bucketCount;
            int countOfBucketsTakingExtraOne = items.Count() % bucketCount;
            T[][] buckets = new T[bucketCount][];
            // Build empty array structure.
            for (int i = 0; i < bucketCount; i++)
            {
                if (i < countOfBucketsTakingExtraOne)
                {
                    buckets[i] = new T[itemsPerBucket + 1];
                }
                else
                {
                    buckets[i] = new T[itemsPerBucket];
                }
            }
  
            // Fill the structure.
            int itemsAdded = 0;
            foreach(var bucket in buckets)
            {
                int grabSize = bucket.Count();
                var grab = items.Skip(itemsAdded).Take(grabSize);
                for (int i = 0; i < grabSize; i++)
                {
                    bucket[i] = grab.ElementAt(i);
                }
                itemsAdded += grabSize;
            }
            return buckets;
        }
