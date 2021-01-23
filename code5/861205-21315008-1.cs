    ObservableCollection<FNode> MyFileList = new ObservableCollection<FNode>();
    public MainWindow()
    {
        MyFileList.Add ( new FNode ( "alpha" ) );
        MyFileList.Add ( new FNode ( "bravo" ) );
        MyFileList.Add ( new FNode ( "charlie" ) );
        InitializeComponent();
        mylistbox.DataContext=MyFileList;
    }
