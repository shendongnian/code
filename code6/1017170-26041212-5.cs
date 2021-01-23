    public SecondWindow(Button firstWindowButton, ListBox firstWindowListBox)
    {
        this.firstWindowButton = firstWindowButton;
        this.firstWindowListBox = firstWindowListBox;
        InitializeComponent();
    }
    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        firstWindowButton.Click += firstWindowButton_Click;
        firstWindowListBox.MouseDoubleClick += firstWindowListBox_MouseDoubleClick;
    }
    void firstWindowListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        if (firstWindowListBox.SelectedItem != null)
        {
            lblShowUser.Content = "First window list box selected item: " + firstWindowListBox.SelectedItem.ToString();
        }
    }
    void firstWindowButton_Click(object sender, RoutedEventArgs e)
    {
        lblShowUser.Content = "First window button clicked on: " + DateTime.Now.ToString();
    }
