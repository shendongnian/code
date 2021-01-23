    public MyProjectViewModel TheProject {get;set;}
    public MainWindow()
    {
        TheProject=new MyProject();
        
        InitializeComponent();
        this.DataContext=TheProject;
    }
