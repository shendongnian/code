    protected override void BeginRun()
    {
        MediaPlayer.Volume = 100;
        MediaPlayer.IsRepeating = true;
        MediaPlayer.Play(backgroundSound);
        base.BeginRun();
    }
