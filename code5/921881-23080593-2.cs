    public WorkerViewModel WorkerViewModel { get; private set; }
    public WorkerDetails()
    {
        InitializeComponent();
        WorkerViewModel = new WorkerViewModel();
        this.DataContext = WorkerViewModel;
    }
