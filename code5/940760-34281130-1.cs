    public DispatcherTimer _myDispatcherTimer = new DispatcherTimer();//to update player position
    void PlaySong(Song song){
        sdPlayer.Minimum = 0;
        sdPlayer.Maximum = song.Duration.Ticks;
        sdPlayer.Value = MediaPlayer.PlayPosition.Ticks;
        tbPlayerPosition.Text = (new DateTime(MediaPlayer.PlayPosition.Ticks)).ToString("mm:ss");
        tbRemainTime.Text = (new DateTime(song.Duration.Ticks - MediaPlayer.PlayPosition.Ticks)).ToString("mm:ss");
        MediaPlayer.Play(song);
        StartTimer();
    }
    public void StartTimer(){
       _myDispatcherTimer.Start();
       _myDispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1000);
       _myDispatcherTimer.Tick += OnTick;
    }
    public void OnTick(object o, EventArgs sender){
        Deployment.Current.Dispatcher.BeginInvoke(() => {
           if (MediaPlayer.State != MediaState.Playing){
                _myDispatcherTimer.Stop();
                _myDispatcherTimer.Tick -= OnTick;
                return;
           }
           
           sdPlayer.Value = MediaPlayer.PlayPosition.Ticks;
           tbPlayerPosition.Text = (new DateTime(MediaPlayer.PlayPosition.Ticks)).ToString("mm:ss");
           tbRemainTime.Text = (new DateTime(MediaPlayer.Queue.ActiveSong.Duration.Ticks - MediaPlayer.PlayPosition.Ticks)).ToString("mm:ss");
         });
         System.Diagnostics.Debug.WriteLine("UpdateTimer...");
    }
