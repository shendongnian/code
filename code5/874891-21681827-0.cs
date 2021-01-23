    byte[] buffer24f = new byte[numSamples * 3];
    Marshal.Copy(Buffer, buffer24f, 0, numSamples);
    for (int j = 0; j < buffer24f.Length; j+=3)
    {
        samples[j / 3] = System.BitConverter.ToSingle(
                new byte[] { 
                    0, 
                    buffer24f[j + 0], 
                    buffer24f[j + 1], 
                    buffer24f[j + 2]
                }, 0);
    }
