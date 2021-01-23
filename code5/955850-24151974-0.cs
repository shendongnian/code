    private List<dynamic> Read24BitSamples(FileStream stream, int startIndex, int endIndex)
    {
        var samples = new List<dynamic>();
        var bytes = ReadBytes(stream, startIndex, endIndex);
        var temp = new List<byte>();
        var paddedBytes = new byte[bytes.Length / 3 * 4];
        // Pad 24-bit samples to 32-bit.
        for (var i = 0; i < bytes.Length; i += 3)
        {
            temp.Add(bytes[i]);     // LSB
            temp.Add(bytes[i + 1]); // 2nd LSB
            temp.Add(bytes[i + 2]); // 2nd MSB
            temp.Add(0);            // MSB
        }
        // BitConverter requires are collection to be an array.
        paddedBytes = temp.ToArray();
        temp = null;
        bytes = null;
        if (audioFormat == WavFormat.PCM)
        {
            for (var i = 0; i < paddedBytes.Length / 4; i++)
            {
                samples.Add(BitConverter.ToInt32(paddedBytes, i * 4));
            }
        }
        else
        {
            for (var i = 0; i < paddedBytes.Length / 4; i++)
            {
                samples.Add(BitConverter.ToInt32(paddedBytes, i * 4) / 8388608f);
            }
        }
        return samples;
    }
