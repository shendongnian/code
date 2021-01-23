    private const string Mp3 = @"http://167.88.113.131:8000/;stream.mp3";
    private MediaPlayer player;
    
    private void IntializePlayer()
           {
                player = new MediaPlayer();
    
                //Tell our player to sream music
                player.SetAudioStreamType(Stream.Music);
    }
    
    private async void Play()
            {
                if (player == null) {
                  IntializePlayer();
                }
    
                try {
                    await player.SetDataSourceAsync(ApplicationContext, Android.Net.Uri.Parse(Mp3));
                    player.PrepareAsync();
                    player.Start();
                }
                catch (Exception ex) {
                    //unable to start playback log error
                    Console.WriteLine("Unable to start playback: " + ex);
                }
            }
