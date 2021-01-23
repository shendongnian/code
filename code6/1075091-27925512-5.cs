    public ObservableCollection<ManagementFunctionModel> mMngModelList{ get; private set; }
    public TestWindow()
    {
        mMngModelList = new ObservableCollection<ManagementFunctionModel>();
        mMngModelList.Add(new ManagementFunctionModel() { RangeLeft = 4 });
        InitializeComponent();
        this.DataContext = this;
    }
