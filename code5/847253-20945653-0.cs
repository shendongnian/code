    private boolean isPlaying = true;
    private void MuteButton_Click(object sender, EventArgs e)
    {
        if (StartUpMusic.IsLoadCompleted)
        {
            if (isPlaying)
                StartUpMusic.Stop();
            else
                StartUpMusic.Play();
            isPlaying = !isPlaying;
        }
    }
