    defaultDevice.AudioEndpointVolume.OnVolumeNotification += new 
        AudioEndpointVolumeNotificationDelegate(
           AudioEndpointVolume_OnVolumeNotification);
    void AudioEndpointVolume_OnVolumeNotification(AudioVolumeNotificationData data)
    {
       VolumeTimer.Interval = 100;  // ms, test to gauge!
       VolumeTimer.Stop();
       VolumeTimer.Start();
    }
    private void VolumeTimer_Tick(object sender, EventArgs e)
    {
       VolumeTimer.Stop();
       // whatever you want to do, when the volume no longer changes:
       yourEvent();         
    }
