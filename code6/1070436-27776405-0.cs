    private bool musicPlaying = false;
    private WMPLib.WindowsMediaPlayer wplayer = null;
    private void button2_Click(object sender, EventArgs e)
    {
        // create player only if necessary
        if(wplayer == null)
        {
            wplayer = new WMPLib.WindowsMediaPlayer();
            wplayer.URL = "Super Mario Bros.mp3";
        }
        // toggle musicPlaying
        musicPlaying = !musicPlaying;
        if (musicPlaying)
        {
            button2.Text = "Music Toggle: ON";
            wplayer.controls.play();
        }
        else
        {
            wplayer.controls.stop();
            button2.Text = "Music Toggle: OFF";
        }
    }
