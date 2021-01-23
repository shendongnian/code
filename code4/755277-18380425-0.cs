    private static int PartitionSum(int[] numbers)
    {
        int result = 0;
        var rangePartitioner = Partitioner.Create(0, numbers.Length);
        Parallel.ForEach(rangePartitioner, (range, loopState) =>
        {
            int subtotal = 0;
            for (int i = range.Item1; i < range.Item2; i++)
                subtotal += numbers[i];
            Interlocked.Add(ref result, subtotal);
        });
        return result;
    }
