    BackgroundAudioPlayer audioPlayer = BackgroundAudioPlayer.Instance;
    public MainPage()
    {
        audioPlayer += OnPlayStateChanged;
        OnPlayStateChanged(audioPlayer.PlayerState);
    }
    private OnPlayStateChanged(object sender, EventArgs e)
    {
        OnPlayStateChanged(audioPlayer.PlayerState);
    }
    private OnPlayStateChanged(PlayState state)
    {
        // Process state here
    }
