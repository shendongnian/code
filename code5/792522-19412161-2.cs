    backgroundSound = Content.Load<SoundEffect>("alarm");
    protected override void BeginRun()
    {
        // I created an instance here but you should keep track of this variable
        // in order to stop it when you want.
        var backSong = backgroundSound.CreateInstance();
        backSong.IsLooped = true;
        backSong.Play();
        base.BeginRun();
    }
