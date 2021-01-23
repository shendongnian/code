    public class MediaPlayer
    {
        /* your video type */ TestVideoMediaPlayer { get; set; }
    
        public MediaPlayer(/* your video type */ testVideoMediaPlayer)
        {
            TestVideoMediaPlayer = testVideoMediaPlayer;
        }
    
        public void SetMediaPlayer(string url, int playerCount, string uiMode, bool visible, bool stretch, bool fullScreen)
        {
             if (url != "")
                {
                    TestVideoMediaPlayer.URL = @"Videos/" + url;
                    TestVideoMediaPlayer.settings.playCount = playerCount;
                    TestVideoMediaPlayer.uiMode = uiMode;
                    TestVideoMediaPlayer.Visible = visible;
                    TestVideoMediaPlayer.stretchToFit = stretch;
                    TestVideoMediaPlayer.fullScreen = fullScreen;
                }
                else
                {
                    TestVideoMediaPlayer.Visible = false;
                }
        }
    }
