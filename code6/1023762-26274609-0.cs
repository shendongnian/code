    public class MyWaveProvider : NAudio.Wave.IWaveProvider
    {
        private readonly NAudio.Wave.IWaveProvider inWaveProvider;
        public MyWaveProvider(NAudio.Wave.IWaveProvider inWaveProvider)
        {
            this.inWaveProvider = inWaveProvider;
            this.WaveFormat = inWaveProvider.WaveFormat;
        }
        public NAudio.Wave.WaveFormat WaveFormat { get; private set; }
        public int Read(byte[] outBuffer, int offset, int count)
        {
            return this.inWaveProvider.Read(outBuffer, offset, count);
        }
    }
