    public static void SubtractBackgroundFromBufferPartitionedParallelForEachHack(
        ushort[] backgroundBuffer)
    {
        Parallel.ForEach(Partitioner.Create(0, Buffer.Length), range =>
            {
                for (int i = range.Item1; i < range.Item2; ++i)
                {
                    unsafe
                    {
                        var nonNegative = Buffer[i] > backgroundBuffer[i];
                        Buffer[i] = (ushort)((Buffer[i] - backgroundBuffer[i]) *
                            *((int*)(&nonNegative)));
                    }
                }
            });
    }
