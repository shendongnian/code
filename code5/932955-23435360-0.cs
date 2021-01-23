    Music = new MediaPlayer();
    Music.Open(new Uri("Sounds/SalusEstudiantv5.mp3", UriKind.Relative));
    Music.MediaEnded += MusicEnded;
    Music.Play();
    
    
    private void MusicEnded(object sender, EventArgs e)
    {
    Music.Stop();
    Music.Play();
    }
