    public static IEnumerable<byte[]> ReadFileInBlocks(string filename, int blockSize)
    {
        byte[] buffer = new byte[blockSize];
        using (var file = File.OpenRead(filename))
        {
            while (true)
            {
                int n = file.Read(buffer, 0, buffer.Length);
                if (n == buffer.Length)
                {
                    yield return buffer;
                }
                else if (n > 0) // Must be the last block in the file (because n != buffer.Length)
                {
                    Array.Resize(ref buffer, n);
                    yield return buffer;         // Just this last block to return,
                    break;                       // and then we're done.
                }
                else // Exactly read to end of file in previous read, so we're already done.
                {
                    break;
                }
            }
        }
    }
