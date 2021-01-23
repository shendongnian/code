    public MainWindow()
    {
        InitializeComponent();
        CurrentDateTimeTextBlock.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        var datecheckObject = new CurrentRentWeek();
        CurrentRentWeekTextBlock.Text = datecheckObject.DateCheck(CurrentRentWeekTextBlock.Text);
    }
