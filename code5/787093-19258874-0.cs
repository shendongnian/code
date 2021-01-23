    private Student s;
    public MainWindow()
    {
        InitializeComponent();
        s = new Student()
    }
    private void btnSet_Click(object sender, RoutedEventArgs e) {
        s.FirstName = txtFirstName.Text;
    }
