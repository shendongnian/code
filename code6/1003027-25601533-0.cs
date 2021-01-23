    <MediaElement x:Name="Sound" AutoPlay="False" 
                      MediaOpened="Sound_MediaOpened" 
                      MediaFailed="Sound_MediaFailed" />
|
        private void Sound_MediaOpened(object sender, RoutedEventArgs e)
        {
            Sound.Play();
        }
        private void Sound_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.ErrorException.Message + " ERROR playing sound " + Sound.Source.ToString());
        }
