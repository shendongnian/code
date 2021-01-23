    public SynchronizationContext UISynchContext { get; private set; }
    public static MainForm Get { get; private set; }
    public MainForm()
    {
        InitializeComponent();
        Get = this;
        UISynchContext = SynchronizationContext.Current;
    }
    public void UpdateText(string labelName, string text)
    {
        var label = (Label)Controls.Find(labelName, true).FirstOrDefault();
        if (label != null) label.Text = text;
    }
