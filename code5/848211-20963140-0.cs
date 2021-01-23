    /// <summary>
    /// Detecting volume changes, the RMS Mothod.
    /// 
    /// RMS(Root mean square)
    /// </summary>
    /// <param name="data">RAW datas</param>
    /// <returns></returns>
    public static void MicrophoneVolume(byte[] data)
    {
        //RMS Method
        double rms = 0;
        ushort byte1 = 0;
        ushort byte2 = 0;
        short value = 0;
        int volume = 0;
        rms = (short)(byte1 | (byte2 << 8));
    
        for (int i = 0; i < data.Length - 1; i += 2)
        {
            byte1 = data[i];
            byte2 = data[i + 1];
    
            value = (short)(byte1 | (byte2 << 8));
            rms += Math.Pow(value, 2);
        }
    
        rms /= (double)(data.Length / 2);
        volume = (int)Math.Floor(Math.Sqrt(rms));
    }
