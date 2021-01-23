    bool gameHasControl = Microsoft.Xna.Framework.Media.MediaPlayer.GameHasControl;
    if (!gameHasControl)
    {
       MessageBox.Show("stopping other player"); // normally you should ask if to do that      
       BackgroundAudioPlayer.Instance.Stop();
    }
