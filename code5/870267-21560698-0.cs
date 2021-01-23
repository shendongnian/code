    public MainPage()
    {
        this.InitializeComponent();
        this.Loaded += MainPage_Loaded;
    }
    
    SpeechRecognizer SR;
    private void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
        // Apply credentials from the Windows Azure Data Marketplace.
        var credentials = new SpeechAuthorizationParameters();
        credentials.ClientId = "<YOUR CLIENT ID>";
        credentials.ClientSecret = "<YOUR CLIENT SECRET>";
    
        // Initialize the speech recognizer and attach to control.
        SR = new SpeechRecognizer("en-US", credentials);
        SpeechControl.SpeechRecognizer = SR;
    }
    
    private async void SpeakButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            // Start speech recognition.
            var result = await SR.RecognizeSpeechToTextAsync();
            ResultText.Text = result.Text;
        }
        catch (System.Exception ex)
        {
            ResultText.Text = ex.Message;
        }
    }
