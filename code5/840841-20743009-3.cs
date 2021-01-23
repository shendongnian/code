                songs = mLibrary.Songs;
                MediaPlayer.ActiveSongChanged += MediaPlayer_ActiveSongChanged;
                MediaPlayer.MediaStateChanged += MediaPlayer_MediaStateChanged;
                if (songs.Count != 0)
                {
                    songnames = new List<SongModel>();
                    for (int i = 0; i < songs.Count; i++)
                    {
                        songnames.Add(new SongModel() { songName = songs[i].Name, songId = i });
                    }
                    lbMusic.ItemsSource = songnames; // lbMusic is the list/listbox here
                }
