      /// <summary>
      /// Method to start the media player playing a file.
      /// </summary>
      /// <param name="fileName">complete file name</param>
      /// <param name="repeatCount">zero = repeat indefinitely, else number of times to repeat</param>
      [SuppressMessage("Microsoft.Usage", "CA2233:OperationsShouldNotOverflow", MessageId = "repeatCount-1")]
      public void PlayMediaFile(string fileName, int repeatCount)
      {
         if (_windowsMediaPlayer == null)
            return;
    
         _repeatCount = --repeatCount;  // Zero -> -1, 1 -> zero, etc.
    
         if (_windowsMediaPlayer.playState == WMPPlayState.wmppsPlaying)
            _windowsMediaPlayer.controls.stop();  // Probably unnecessary
    
         _windowsMediaPlayer.URL = fileName;
         _windowsMediaPlayer.controls.play();
      }
...
      /// <summary>
      /// Event-handler method called by Windows Media Player when the "state" of the media player 
      /// changes. This is used to repeat the playing of the media for the specified number of 
      /// times, or maybe for an indeterminate number of times.
      /// </summary>
      private void WindowsMediaPlayer_PlayStateChange(int newState)
      {
         if ((WMPPlayState)newState == WMPPlayState.wmppsStopped)
         {
            if (_repeatCount != 0)
            {
               _repeatCount--;
               _windowsMediaPlayer.controls.play();
            }
         }
      }
