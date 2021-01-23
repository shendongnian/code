    public static void SubtractBackgroundFromBuffer(ushort[] backgroundBuffer)
    {
        int bufferLength = Buffer.Length;
        for (int index = 0; index < bufferLength; index++)
        {
            int difference = Buffer[index] - backgroundBuffer[index];
            if (difference >= 0)
                Buffer[index] = (ushort)difference;
            else
                Buffer[index] = 0;
        }
    }
    public static void SubtractBackgroundFromBufferWithCalcOpt(ushort[] backgroundBuffer)
    {
        int bufferLength = Buffer.Length;
        for (int index = 0; index < bufferLength; index++)
        {
            if (Buffer[index] < backgroundBuffer[index])
            {
                Buffer[index] = 0;
            }
            else
            {
                Buffer[index] -= backgroundBuffer[index];
            }
        }
    }
    public static void SubtractBackgroundFromBufferParallelFor(ushort[] backgroundBuffer)
    {
        Parallel.For(0, Buffer.Length, (i) =>
        {
            int difference = Buffer[i] - backgroundBuffer[i];
            if (difference >= 0)
                Buffer[i] = (ushort)difference;
            else
                Buffer[i] = 0;
        });
    }        
    public static void SubtractBackgroundFromBufferBlockParallelFor(ushort[] backgroundBuffer)
    {
        int blockSize = 4096;
        Parallel.For(0, (int)Math.Ceiling(Buffer.Length / (double)blockSize), (j) =>
        {
            for (int i = j * blockSize; i < (j + 1) * blockSize; i++)
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
