    private Settings _settings;
    
    public HM_SettingsForm(Settings settings)
    {
        InitializeComponent();
        _settings = settings;
        titleTextBox.Text = settings.Title;
        // ..another props inialization
    }
    public void FormClose(object Sender, EventArgs args)
    {
        _settings.Title = titleTextBox.Text;
        // ..another props updating
    }
