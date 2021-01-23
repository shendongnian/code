    private List<dynamic> Read24BitSamples(FileStream stream, int startIndex, int endIndex)
    {
        var samples = new List<dynamic>();
        var bytes = ReadBytes(stream, startIndex, endIndex);
        var temp = new List<byte>();
        var paddedBytes = new byte[bytes.Length / 3 * 4];
		
        // Right align our samples to 32-bit (effectively bit shifting 8 places to the left).
        for (var i = 0; i < bytes.Length; i += 3)
        {
            temp.Add(0);            // LSB
            temp.Add(bytes[i]);     // 2nd LSB
            temp.Add(bytes[i + 1]); // 2nd MSB
            temp.Add(bytes[i + 2]); // MSB
        }
        // BitConverter requires collection to be an array.
        paddedBytes = temp.ToArray();
        temp = null;
        bytes = null;
        if (audioFormat == WavFormat.PCM)
        {
            for (var i = 0; i < paddedBytes.Length / 4; i++)
            {
                samples.Add(BitConverter.ToInt32(paddedBytes, i * 4) >> 8);
            }
        }
        else
        {
            for (var i = 0; i < paddedBytes.Length / 4; i++)
            {
                samples.Add(BitConverter.ToInt32(paddedBytes, i * 4) / 2147483648f); // Skip the bit shift and just divide, since our sample has been "shited" 8 places to the right we need to divide by 2147483648, not 8388608.
            }
        }
        return samples;
    }
