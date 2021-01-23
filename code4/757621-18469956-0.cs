       public RadioGroup()
        {
            InitializeComponent();
            Loaded += RadioGroup_Loaded;
        }
    void RadioGroup_Loaded(object sender, RoutedEventArgs e)
    {
        ((RadioButton)VisualTreeHelper.GetChild((container.ItemContainerGenerator.ContainerFromIndex(SelectedIndex)), 0)).IsChecked = true;
    }
