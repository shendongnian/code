    private static double _pos = 0;
    protected override void OnPlayStateChanged(BackgroundAudioPlayer player, AudioTrack track, PlayState playState)
    {
        switch (playState)
        {
           case PlayState.Shutdown:
                IsolatedStorageSettings IS = IsolatedStorageSettings.ApplicationSettings;
                if (IS.Contains("position")) IS["position"] = _pos;
                else IS.Add("position", _pos);
                IS.Save(); // remember to save
                // rest of the code
    // And somewhere where you want to bring your position back (for example when your BAP starts):
    // to retrive the position:
    IsolatedStorageSettings IS = IsolatedStorageSettings.ApplicationSettings;
    if (IS.Contains("position")) _pos = (double)IS["position"];
    else _pos = 0;
    // rest of the code
