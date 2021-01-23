    public RelayCommand Maximize { get; set; }
    
    public RelayCommand Play { get; set; }
    
    private MediaElement media;
    // Bound media property with notification
    public MediaElement Media
    {
        get
        {
            return this.media;
        }
        set
        {
            this.media = value;
            // Modify following line as needed
            // to any custom Property changed handler
            this.Changed("Media");
        }
    }
    // Constructor, setup the command, media element etc.
    public ViewModel()
    {
        // Two button commands
        this.Maximize = new RelayCommand(this.ExecuteMaximizeCommand);
        this.Play = new RelayCommand(this.ExecutePlayCommand);
    
        // The Media element
        this.Media = new MediaElement();
                
        // This is where we need to set Loaded and Unloaded behavior to Manual
        // This means video won't play right-away after loading
        // You will have to call .Play() method to start playback
        // Add a play button if you don't have one and bind the Play command
        this.Media.LoadedBehavior = MediaState.Manual;
        this.Media.UnloadedBehavior = MediaState.Manual;
        // Following is just an example. Doesn't need to be here
        this.Media.Source = new Uri("test.mp4", UriKind.Relative);
                
    }
    
    
    public void ExecuteMaximizeCommand()
    {            
        var fullscreen = new FullScreen();
    
        // We need to handle the Closing event
        // So that we can trigger the playback
        // to continue in the smaller window
        fullscreen.Closing += fullscreen_Closing;
        fullscreen.DataContext = this;
        fullscreen.ShowDialog();
    }
    
    public void ExecutePlayCommand()
    {
        this.Media.Play();
    }
    
    // Event handler for fullscreen window closing
    void fullscreen_Closing(object sender, CancelEventArgs e)
    {
        // Trigger the Property Change Notification
        // by forcing null and then back to original value
        // This will trigger the binding to kick-in again
        // which will redraw the MediaElement UI and continue
        // the playback
        var temp = this.Media;
        this.Media = null;
        this.Media = temp;
    }
    
