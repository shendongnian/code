    using System.ComponentModel; //This is the reference needed.
    private void KickBasicPlay(object sender, RoutedEventArgs e)
    {
        BackgroundWorker thread = new BackgroundWorker();
        thread.DoWork += (sender, e) => { KickBasicAudio.Play() };
    }
