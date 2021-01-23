    private SounData selected = null;
    private void LongListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
       LongListSelector selector = sender as LongListSelector;
       if (AudioPlayer.CurrentState == System.Windows.Media.MediaElementState.Playing &&
        ((SoundData)selector.SelectedItem == selected))
       {
         AudioPlayer.Stop();
         selector.SelectedItem = null;
       }
       else
       {
         SoundData data = selector.SelectedItem as SoundData;
         // verifying our sender is actually SoundData
         if (data == null)
            return;
         AudioPlayer.Source = new Uri(data.FilePath, UriKind.RelativeOrAbsolute);
         // resetting selected so we can play the same sound over and over again
         selected = data;
         selector.SelectedItem = null;
       }
    }
