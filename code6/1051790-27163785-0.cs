        public static List<List<T>> Split<T>(this IEnumerable<T> collection, Int32 groupSize)
        {
            var collectionList = collection.ToList();
            if (groupSize > collectionList.Count)
                groupSize = collectionList.Count;
            var chunks = new List<List<T>>();
            while (collectionList.Any())
            {
                var chunk = collectionList.Take(groupSize);
                chunks.Add(chunk.ToList());
                collectionList = collectionList.Skip(groupSize).ToList();
            }
            // Noticed this just now, but think you want to add chunks.Add(collectionList) to make sure that the last group is accounted for.
            return chunks;
        }
        public static List<List<T>> Split<T>(this IEnumerable<T> collection, Func<T, Boolean> splitFunction)
        {
            var collectionList = collection.ToList();
            if (collectionList.IsNullOrEmpty())
                return new List<List<T>>();
            var indices = collectionList.FindIndices(splitFunction); // Custom method that searches for the indices that satisfy the predicate and returns the index of each matching item in the list.
            if (indices.IsNullOrEmpty()) // equivalent to indices == null || !indices.Any()
                return new List<List<T>> { collectionList };
            var chunks = new List<List<T>>();
            var lastIndex = 0;
            if (indices[0] > 0)
            {
                chunks.Add(collectionList.Take(indices[0]).ToList());
                lastIndex = indices[0];
            }
            for (var i = 1; i < indices.Count; i++)
            {
                var chunkSize = indices[i] - lastIndex;
                var chunk = collectionList.Skip(lastIndex).Take(chunkSize).ToList();
                if (chunk.IsNullOrEmpty())
                {
                    break;
                }
                chunks.Add(chunk);
                lastIndex = indices[i];
            }
            if (collectionList.Count - lastIndex > 0)
            {
                var lastChunk = collectionList.Skip(lastIndex).ToList();
                chunks.Add(lastChunk);
            }
            return chunks;
        }
