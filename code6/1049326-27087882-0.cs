     private SoundPlayer _player;
 
     private void Play()
     {
         string soundFile = @"D:\Song.wav";
         _player = new System.Media.SoundPlayer(soundFile); 
         _player.Play();
     }
     private void Stop()
     {
         if (_player != null)
         {
              _player.Stop();
         }
     }
