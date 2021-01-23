    public MyView()
    {
        InitializeComponent();
        Loaded += OnLoaded;
    }
    private void comboBox1_DropDownOpened(object sender, EventArgs e)
    {
        comboBox1.ItemsSource = MyClass.GetComboBoxList();
    }
    private void OnLoaded(object sender, RoutedEventArgs e)
    {
       comboBox1.IsDropDownOpen = true;
       comboBox1.IsDropDownOpen = false;
    }
