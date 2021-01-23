    AudioRoutingManager.GetDefault().AudioEndpointChanged += AudioEndpointChanged;
    public void AudioEndpointChanged(AudioRoutingManager sender, object args) 
    {
      var AudioEndPoint = sender.GetAudioEndpoint();
      switch (AudioEndPoint)
      {
         case AudioRoutingEndpoint.WiredHeadset:
              MessageBox.Show("Headset connected");
              break;
      }
    }
