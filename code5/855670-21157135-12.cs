        public static void SubtractBackgroundFromBuffer(ushort[] backgroundBuffer)
        {
            Parallel.ForEach(Partitioner.Create(0, Buffer.Length), range =>
                {
                    for (int i = range.Item1; i < range.Item2; ++i)
                    {
                        if (Buffer[i] < backgroundBuffer[i])
                        {
                            Buffer[i] = 0;
                        }
                        else
                        {
                            Buffer[i] -= backgroundBuffer[i];
                        }
                    }
                });
        }
