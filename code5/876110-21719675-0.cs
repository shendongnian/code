    private Stream CreateAudioStream()
    {
        var source = KinectSensor.KinectSensors[0].AudioSource;
        source.NoiseSuppression = _isNoiseSuppressionOn;
        source.AutomaticGainControlEnabled = _isAutomaticGainOn;
        return source.Start();
    }
    private object lockObj = new object();
    private void RecordKinectAudio()
    {
        lock (lockObj)
        {
            using (var source = CreateAudioStream())
            {
            }
        }
    }
