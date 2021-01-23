    public IEnumerable<string> ConvertToBase64StringInBlocks(string filename, int blockSize)
    {
        byte[] buffer = new byte[blockSize];
        using (var file = File.OpenRead(filename))
        {
            while (true)
            {
                int n = file.Read(buffer, 0, buffer.Length);
                if (n == 0) // Exactly read to end of file in previous read, so we're already done.
                {
                    break;
                }
                else
                {
                    yield return Convert.ToBase64String(buffer, 0, n);
                }
            }
        }
    }
