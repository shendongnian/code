    using NAudio;
    using NAudio.CoreAudioApi;
    
    private static MMDeviceEnumerator enumer = new MMDeviceEnumerator();
    private MMDevice dev = enumer.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
    public void Form1_Load(object sender, EventArgs e){
        dev.AudioEndpointVolume.OnVolumeNotification += AudioEndpointVolume_OnVolumeNotification;
    }
    void AudioEndpointVolume_OnVolumeNotification(AudioVolumeNotificationData data)
    {
        // This shows data.MasterVolume, you can do whatever you want here
        MessageBox.Show(data.MasterVolume.ToString());
    }
