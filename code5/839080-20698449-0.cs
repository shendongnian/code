         public event EventHandler CurrentPositionChanged;
         public double CurrentPosition
         {
             get { return _mediaPlayer.CurrentPosition; }
             set
             {
                 _mediaPlayer.SeekTo(value);
             }
         }
