    Stream _mp3Output;
    Mp3Writer _mp3Writer;
    private void InitAudioOut(DateTime recordMarker)
    {
        string pathOut = string.Format(@"C:\Rec\({0:HH-mm-ss dd-MM-yyyy} OUT).mp3", recordMarker);
        
        _waveOut = new WasapiLoopbackCapture();
        _waveOut.DataAvailable += WaveOutDataAvailable;
        _waveOut.RecordingStopped += WaveOutRecordStopped;
        _mp3Output = File.Create(pathIn);
        var fmt = new WaveLib.WaveFormat(_waveOut.WaveFormat.SampleRate, 16, _waveOut.Channels);
        var beconf = new Yeti.Lame.BE_CONFIG(fmt, 128);
        _mp3Writer = new Mp3Writer(_mp3Stream, fmt, beconf);
        _waveOut.StartRecording();
    }
    private void WaveOutDataAvailable(object sender, WaveInEventArgs e)
    {
        if (_mp3Writer != null)
        {
            byte[] data = Float32toInt16(e.Buffer, 0, e.BytesRecorded);
            _mp3Writer.Write(data, 0, data.Length);
        }
    }
    private void WaveOutRecordStopped(object sender, StoppedEventArgs e)
    {
        if (InvokeRequired)
            BeginInvoke(new MethodInvoker(WaveOutStop));
        else
            WaveOutStop();
    }
    private void WaveOutStop()
    {
        if (_mp3Writer != null)
        {
            _mp3Writer.Close();
            _mp3Writer.Dispose();
            _mp3Writer = null;
        }
        if (_mp3Stream != null)
        {
            _mp3Stream.Dispose();
            _mp3Stream = null;
        }
        _waveOut.Dispose();
        _waveOut = null;
    }
