    public static class IEnumerableExtender
    {
        public static IEnumerable<T> Mix<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            var firstCount = first.Count();
            var secondCount = second.Count();
            // it is important that `first` is equal or larger
            // than `second`, if it is not, we swap
            if (firstCount < secondCount)
            {
                var a = first;
                first = second;
                second = a;
                firstCount = first.Count();
                secondCount = second.Count();
            }
            // at every `N` number of elements we will insert
            // one from the `second` list
            var insertAtEvery = Math.Floor(firstCount / (double)secondCount) + 1;
            int totalLength = firstCount + secondCount;
            var listResult = new List<T>(totalLength);
            for (int i = 0, x = 0, y = 0; i < totalLength; ++i)
            {
                // if it is time to insert an element from `second`
                // and there is still something to be inserted
                if ((i % insertAtEvery) == 0 && y < secondCount)
                {
                    // insert and move the index from the `second`
                    listResult.Add(second.ElementAt(y++));
                }
                else
                {
                    // insert and move the index from the `first`
                    listResult.Add(first.ElementAt(x++));
                }
            }
            return listResult;
        }
    }
