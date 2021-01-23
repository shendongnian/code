    MediaElement me;
    private void StartButtonClicked(object sender, RoutedEventArgs e)
    {
      me = new MediaElement();
      // Register for critical events. CurrentStateChanged is also useful
      me.MediaOpened += MediaElementMediaOpened;
      me.MediaFailed += MediaElementMediaFailed;
      // Start opening the file
      me.Source = new Uri("ms-appx:///Assets/WestEndGirls.wma");
      // Add to the XAML tree (assumes a Panel with the name "Root")
      Root.Children.Add(me);
    }
    // Errors will be reported here
    void MediaElementMediaFailed(object sender, ExceptionRoutedEventArgs e)
    {
      Debug.WriteLine(e.ErrorMessage);
    }
    // Only once the media has been opened can you play it
    void MediaElementMediaOpened(object sender, RoutedEventArgs e)
    {
      me.Play();
    }
