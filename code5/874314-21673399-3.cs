    public TestView()
    {
        InitializeComponent();
        classInOtherAssemblyReference.BackgroundWorker.WorkerReportsProgress = true;
        classInOtherAssemblyReference.BackgroundWorker.ProgressChanged += ProgressChanged;
        classInOtherAssemblyReference.BackgroundWorker.DoWork += DoWork;
    }
