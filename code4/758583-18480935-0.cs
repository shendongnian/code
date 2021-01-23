    [MethodImpl(MethodImplOptions.NoOptimization)]
    public void TakeRam(int X, int Y)
    {
        Byte[] doubleArray = new Byte[X];
        for (int i = 0; i < X; i++)
        {
            doubleArray[i] = 0xFF;
        }
        System.Threading.Sleep(Y)
        GC.KeepAlive(doubleArray);
    }
