        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();  // new random variable
            MediaLibrary mediaLib = new MediaLibrary(); // this is where it grabs your whole music library and enumerates everything.  If you break here, you can see it.
            AlbumCollection albums = mediaLib.Albums;  // pick which song you want.
            Album album = albums[random.Next(albums.Count)];
            SongCollection songs = mediaLib.Songs;
            Song song = songs[random.Next(songs.Count)];
            MediaPlayer.Play(song); // this plays the song.
        }
