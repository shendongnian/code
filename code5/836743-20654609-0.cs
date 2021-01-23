    void Main()
    {
        const long gb = 1024 * 1024 * 1024;
        using (var stream = new FileStream(@"d:\temp\largefile.bin", FileMode.Open))
        {
            stream.Position = 2 * gb; // 3rd gb-chunk
            byte[] buffer = new byte[32768];
            long amount = 1 * gb;
    
            using (var hashAlgorithm = SHA1.Create())
            {
                while (amount > 0)
                {
                    int bytesRead = stream.Read(buffer, 0,
                        (int)Math.Min(buffer.Length, amount));
                    if (bytesRead > 0)
                    {
                        amount -= bytesRead;
                        if (amount > 0)
                            hashAlgorithm.TransformBlock(buffer, 0, bytesRead,
                                buffer, 0);
                        else
                            hashAlgorithm.TransformFinalBlock(buffer, 0, bytesRead);
                    }
                    else
                        throw new InvalidOperationException();
                }
                hashAlgorithm.Hash.Dump();
            }
        }
    }
