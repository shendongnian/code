    IEnumerable<byte> ConvertTo16Bit(byte[] data, int skipBytes)
    {
        int bytesToRead = 0;
        int bytesToSkip = skipBytes;
        int readIndex = 0;
        while (readIndex < data.Length)
        {
            if (bytesToSkip > 0)
            {
                readIndex += bytesToSkip;
                bytesToSkip = 0;
                bytesToRead = 2;
                continue;
            }
            if (bytesToRead == 0)
            {
                bytesToSkip = skipBytes;
                continue;
            }
            yield return data[readIndex++];
            bytesToRead--;
        }
    }
