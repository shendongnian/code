    double[] original = {1.0, 2.0, 3.0, 4.0, 5.0};
    int byteCount = sizeof(double) * original.Length;
    byte[] asBytes = new byte[byteCount];
    Buffer.BlockCopy(original, 0, asBytes, 0, byteCount);
    double[] copied = new double[original.Length];
    Buffer.BlockCopy(asBytes, 0, copied, 0, byteCount);
    foreach (double d in copied)
        Console.WriteLine(d);
