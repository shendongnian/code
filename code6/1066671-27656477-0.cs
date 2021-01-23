    byte[] length = new byte[4];
    // TODO: Validate that bytesRead is 4 after this... it's unlikely but *possible*
    // that you might not read the whole length in one go.
    bytesRead = netStream.Read(length, 0, 4);
    int bytesLeft = BitConverter.ToInt32(length,0);
    byte[] buffer = new byte[32 * 1024]; // Copy up to 32K at a time
    using (var output = File.Create(@"D:\Javed\Miscellaneous\" + shortFileName))
    {
        while (bytesLeft > 0)
        {
            int bytesRead = netStream.Read(buffer, 0, Math.Min(bytesLeft, buffer.Length));
            if (bytesRead == 0)
            {
                throw new IOException("Unexpected end of data");
            }
            output.Write(buffer, 0, bytesRead);
            bytesLeft -= bytesRead;
        }
    }
