        public static IEnumerable<List<T>> Partition<T>(IEnumerable<T> list, Func<T, long> getValue, long maxSum)
        {
            long sum = 0;
            int partition = 0;
            var query = list.Select((i, index) =>
                {
                    if (index == 0)
                    {
                        // Reset the external partition counter in case the query is run multiple times.
                        sum = 0;
                        partition = 0;
                    }
                    var value = getValue(i);
                    sum = sum + value;
                    if (sum > maxSum)
                    {
                        sum = value;
                        partition++;
                    }
                    return new KeyValuePair<int, T>(partition, i);
                })
                .GroupBy(pair => pair.Key)
                .Select(g => g.Select(pair => pair.Value).ToList());
            return query;
        }
