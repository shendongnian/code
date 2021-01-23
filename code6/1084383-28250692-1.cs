    SystemMediaTransportControls systemControls;
    public BlankPage7()
    {
        this.InitializeComponent();
        // Hook up app to system transport controls.
        systemControls = SystemMediaTransportControls.GetForCurrentView();
        systemControls.ButtonPressed += SystemControls_ButtonPressed;
        // Register to handle the following system transpot control buttons.
        systemControls.IsPlayEnabled = true;
        systemControls.IsPauseEnabled = true;
    }
    private void SystemControls_ButtonPressed(SystemMediaTransportControls sender, SystemMediaTransportControlsButtonPressedEventArgs args)
    {
        switch (args.Button)
        {
            case SystemMediaTransportControlsButton.Play:
                PlayMedia();
                break;
            case SystemMediaTransportControlsButton.Pause:
                PauseMedia();
                break;
            default:
                break;
        }
    }
    private void MusicPlayer_CurrentStateChanged(object sender, RoutedEventArgs e)
    {
        switch (musicPlayer.CurrentState)
        {
            case MediaElementState.Playing:
                systemControls.PlaybackStatus = MediaPlaybackStatus.Playing;
                break;
            case MediaElementState.Paused:
                systemControls.PlaybackStatus = MediaPlaybackStatus.Paused;
                break;
            case MediaElementState.Stopped:
                systemControls.PlaybackStatus = MediaPlaybackStatus.Stopped;
                break;
            case MediaElementState.Closed:
                systemControls.PlaybackStatus = MediaPlaybackStatus.Closed;
                break;
            default:
                break;
        }
    }
    async void PlayMedia()
    {
        await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
        {
        musicPlayer.Play();
        });
    }
    async void PauseMedia()
    {
        await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
        {
        musicPlayer.Pause();
        });
    }
    protected override void OnNavigatedFrom(NavigationEventArgs e)
    {
        if (systemControls != null)
        {
            systemControls.ButtonPressed -= SystemControls_ButtonPressed;
            systemControls.IsPlayEnabled = false;
            systemControls.IsPauseEnabled = false;
            systemControls.PlaybackStatus = MediaPlaybackStatus.Closed;
        }
    }
