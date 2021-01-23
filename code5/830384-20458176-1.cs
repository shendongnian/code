    public DisplayScenario()
    {
        InitializeComponent();
        this.Loaded += DisplayScenario_Loaded;
    }
    void DisplayScenario_Loaded(object sender, RoutedEventArgs e)
    {
        QuestionsList.ItemsSource = QuestionList;
    }
