    /// <summary>
    /// Play a filename
    /// </summary>
    /// <param name="fileName">filename</param>
    public void Play(string fileName)
    {
        this.VlcControl.Media = new Vlc.DotNet.Core.Medias.PathMedia(fileName);
        Task.Factory.StartNew(this.Mute);
    }
    /// <summary>
    /// Mute audio
    /// </summary>
    private void Mute()
    {            
        this.VlcControl.AudioProperties.IsMute = true;
        if (!this.VlcControl.AudioProperties.IsMute)
        {
            // Retry mute
            Task.Factory.StartNew(this.Mute);
        }
     }
