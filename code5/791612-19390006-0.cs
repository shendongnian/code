    // Declaration:
    private string firstname = "";
    private string lastname = "";
    private string course = "";
    private string mno = "";
    private string yrmark = "";
    
    public MainWindow()
    {
        InitializeComponent();
    }
    
    public void SetBttn_Click(object sender, RoutedEventArgs e)
    {
        firstname = FirstNameTxtBox.Text;
        lastname = LastNameTxtBox.Text;
        course = CourseTxtBox.Text;
        mno = MNoTxtBox.Text;
        yrmark = YrMarkTxtBox.Text;
    }
