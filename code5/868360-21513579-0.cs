    public MainPage()
    {
       InitializeComponent();
       myButton.Click += (sender, e) => { beep.Play(); };
       // this below checks if your file exists 
       if (Application.GetResourceStream(new Uri("beep.mp3", UriKind.Relative)) == null)
            MessageBox.Show("File not Exists!");
    }
    private void beep_MediaFailed(object sender, ExceptionRoutedEventArgs e)
    {
       //  Show Message when opening failed 
       MessageBox.Show("There was an error: " + e.ErrorException.Message);
    }
    private void beep_MediaOpened(object sender, RoutedEventArgs e)
    {
       // as it's subscribed in xaml, juts after opening the App you should hear beep
       beep.Play();
       MessageBox.Show("Media opened");
    }
