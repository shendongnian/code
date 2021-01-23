    private void listbox1_tapped(object sender, TappedRoutedEventArgs e)
            {
               var selectedSong = (Song)listbox1.SelectedItem;
               if (selectedSong != null) {
                  var val = selectedSong.Value;
                  }
            }
