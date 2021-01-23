    using System.Media; //The reference needed.
    private SoundPlayer _player = new SoundPlayer("file");
    
    private void KickBasicPlay(object sender, RoutedEventArgs e)
    {
        _player.Play();
    }
