    private static void Main(string[] args)
    {
        TimeSpan startTimeSpan = TimeSpan.FromSeconds(20);
        TimeSpan endTimeSpan = TimeSpan.FromSeconds(50);
        using (IWaveSource source = CodecFactory.Instance.GetCodec(@"C:\Temp\test.mp3"))
        using (MediaFoundationEncoder mediaFoundationEncoder =
            MediaFoundationEncoder.CreateWMAEncoder(source.WaveFormat, @"C:\Temp\dest0.mp3"))
        {
            AddTimeSpan(source, mediaFoundationEncoder, startTimeSpan, endTimeSpan);
        }
    }
    private static void AddTimeSpan(IWaveSource source, MediaFoundationEncoder mediaFoundationEncoder, TimeSpan startTimeSpan, TimeSpan endTimeSpan)
    {
        source.SetPosition(startTimeSpan);
        int read = 0;
        long bytesToEncode = source.GetBytes(endTimeSpan - startTimeSpan);
        var buffer = new byte[source.WaveFormat.BytesPerSecond];
        while ((read = source.Read(buffer, 0, buffer.Length)) > 0)
        {
            int bytesToWrite = (int)Math.Min(read, bytesToEncode);
            mediaFoundationEncoder.Write(buffer, 0, bytesToWrite);
            bytesToEncode -= bytesToWrite;
        }
    }
