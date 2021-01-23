    if (this.BackgroundAudioPlayer != null)
    {
       if (this.BackgroundAudioPlayer.Instance != null)
       {
           if (this.BackgroundAudioPlayer.Instance.Track != null)
           {
               this._newValue= yourAPI.GetTitleOfTrack();
               
               try
               {
                   /* First try to get the current Track as own Var */
                   this._tempTrack = this.BackgroundAudioPlayer.Instance.Track;
		           if (this._tempTrack != null)
                   {
                      /* Then Read the .Tag Value from it, save to _currentValue */
                      if (this._tempTrack.Tag != null) 
                      { this._currentValue = this._tempTrack.Tag.ToString(); }
                      else
                      { this._currentValue = string.Empty; }
                      /* Compare */
                      if (this._currentValue != this._newValue)
                      {
                         /* Edit the Track Tag from your original BAP */
                         this.BackgroundAudioPlayer.Instance.Track.Tag = this._newValue;
                      }
                   }
               }
               catch(Exception ex)
               {
                   /* if something Crashes you can save the exception error for protocol */
               }
           }
       }
    }
