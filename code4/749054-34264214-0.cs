    App.Handler.MediaPlayerQueqeLists = new ObservableCollection<SongModel>();
    for (int i = 0; i < MediaPlayer.Queue.Count; i++)
    {
      App.Handler.MediaPlayerQueqeLists.Add(new SongModel
      {
          Index = i,
          Title = MediaPlayer.Queue[i].Name,
          Artist = MediaPlayer.Queue[i].Artist.Name,
         StringDuration = (new DateTime(MediaPlayer.Queue[i].Duration.Ticks)).ToString("mm:ss")
      });
    }
    llsPlaylist.ItemsSource = App.Handler.MediaPlayerQueqeLists;
