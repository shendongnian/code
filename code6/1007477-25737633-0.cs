    public static class Extensions
    {
        public static async Task ExecuteInPartition<T>(IEnumerator<T> partition, Func<T, Task> body)
        {
            using (partition)
                while (partition.MoveNext())
                    await body(partition.Current);
        }
        public static Task ForEachAsync<T>(this IEnumerable<T> source, int dop, Func<T, Task> body)
        {
            return Task.WhenAll(
                from partition in Partitioner.Create(source).GetPartitions(dop)
                select ExecuteInPartition(partition, body));
        }
    }
    public Task MainProcess()
    {
        // Process 100 emails at a time
        return emailsToProcess.ForEachAsync(100, async (m) =>
        {
            await ProcessSingleEmail(m);                
        });
       
        _emailsToProcessRepository.MarkBatchAsProcessed(emailsToProcess);
    }
