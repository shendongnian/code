    void AudioEndpointVolume_OnVolumeNotification(AudioVolumeNotificationData data)
    {
       VolumeTimer.Interval = 100;  // ms, test to gauge!
       VolumeTimer.Stop();
       VolumeTimer.Start();
       if (!VolumeUiTimer.Enabled) 
          { VolumeUiTimer.Interval = 2000; VolumeUiTimer.Start();
    }
    private void VolumeTimer_Tick(object sender, EventArgs e)
    {  // no more changes: all timers stop, update UI
       VolumeTimer.Stop();
       VolumeUiTimer.Stop();
       // whatever you want to do, when the volume no longer changes:
       yourEvent();         
    }
    private void VolumeUiTimer_Tick(object sender, EventArgs e)
    {  //restart timer1, stop timer2, update UI 
       VolumeTimer.Stop();
       VolumeTimer.Start();
       VolumeUiTimer.Stop();
       // whatever you want to do, when the volume no longer changes:
       yourEvent();         
    }
