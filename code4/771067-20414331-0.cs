    // Other inputs are also usable. Just look through the NAudio library.
    private IWaveIn waveIn; 
    private static int fftLength = 8192; // NAudio fft wants powers of two!
    // There might be a sample aggregator in NAudio somewhere but I made a variation for my needs
    private SampleAggregator sampleAggregator = new SampleAggregator(fftLength);
    
    public Main()
    {
        sampleAggregator.FftCalculated += new EventHandler<FftEventArgs>(FftCalculated);
        sampleAggregator.PerformFFT = true;
        // Here you decide what you want to use as the waveIn.
        // There are many options in NAudio and you can use other streams/files.
        // Note that the code varies for each different source.
        waveIn = new WasapiLoopbackCapture(); 
        waveIn.DataAvailable += OnDataAvailable;
        waveIn.StartRecording();
    }
    void OnDataAvailable(object sender, WaveInEventArgs e)
    {
        if (this.InvokeRequired)
        {
            this.BeginInvoke(new EventHandler<WaveInEventArgs>(OnDataAvailable), sender, e);
        }
        else
        {
            byte[] buffer = e.Buffer;
            int bytesRecorded = e.BytesRecorded;
            int bufferIncrement = waveIn.WaveFormat.BlockAlign;
            for (int index = 0; index < bytesRecorded; index += bufferIncrement)
            {
                float sample32 = BitConverter.ToSingle(buffer, index);
                sampleAggregator.Add(sample32);
            }
        }
    }
    void FftCalculated(object sender, FftEventArgs e)
    {
        // Do something with e.result!
    }
