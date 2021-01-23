    private void lbMusic_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        try
        {
            if (lbMusic.SelectedIndex != -1)
            {
                int musicId = (lbMusic.SelectedItem as SongModel).songId;
                MediaPlayer.Play(songs, musicId);
            }
        }
        catch
        {
            MessageBox.Show(TextResources.resErrorActiveSong);
        }
    }
