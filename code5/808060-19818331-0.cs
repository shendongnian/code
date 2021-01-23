    for (long i = 1; i < long.MaxValue; i++)
    {
        var bytes = new byte[16];
        var lngBytes = BitConverter.GetBytes(i);
        Array.Copy(lngBytes, bytes, 8);
        Array.Reverse(bytes);
        var guid = new Guid(bytes);
    }
