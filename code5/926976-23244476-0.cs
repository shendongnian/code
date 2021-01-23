    protected override void OnCreate(Bundle bundle)
    {
        base.OnCreate(bundle);
        SetContentView(Resource.Layout.MyView);
        // Set the hardware buttons to control the music
        this.VolumeControlStream = Stream.Music;
        // Load the sound
        _soundPool = new SoundPool(10, Stream.Music, 0);
        _beepId = _soundPool.Load(this, Resource.Raw.beep, 1);
    }
    private void PlaySound(int soundId)
    {
        var audioManager = (AudioManager)GetSystemService(AudioService);
        var actualVolume = (float)audioManager.GetStreamVolume(Stream.Music);
        var maxVolume = (float)audioManager.GetStreamMaxVolume(Stream.Music);
        var volume = actualVolume / maxVolume;
        _soundPool.Play(soundId, volume, volume, 1, 0, 1f);
    }
