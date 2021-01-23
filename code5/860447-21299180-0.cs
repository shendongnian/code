    private boolean playing = true;
    private void muteButton_Click(object sender, EventArgs e)
    {
        if (_soundPlayer.IsLoadCompleted)
        {
            if (playing)
               {
                _soundPlayer.Stop();
                playing = false;
                }
            else
                {
                _soundPlayer.Play();
                 playing = true;
                }
        }
    }
