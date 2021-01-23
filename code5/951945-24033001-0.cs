    private bool isMediaLoaded = false;
    private bool isPlayCalled = false;
    private void PlayMP3()
    {
        if(isMediaLoaded)
           media.Play();
        else
           isPlayCalled = true;
    }
    void MediaElement1_MediaOpened(object sender, RoutedEventArgs e)
    {
        isMediaLoaded = true;
        if(isPlayCalled)
            MediaElement1.Play();
            
    }
   
