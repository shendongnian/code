    private void objMediaPlayer_MediaEnded(object sender, RoutedEventArgs e)
    {
        if (currentSongIndex == -1)
        {
            currentSongIndex = mediaItemList.SelectedIndex;
        }
        currentSongIndex++;
        if (currentSongIndex < mediaItemList.Items.Count)
        {
            objMediaPlayer.Open(new Uri(mediaItemList.ElementAt(currentSongIndex), 
                UriKind.Absolute));            
        }
        else
        {
            // last song in listbox has been played
        }           
    }
    private void MediaPlayer_MediaOpened(object sender, EventArgs e)
    {
        objMediaPlayer.Play();
    }
