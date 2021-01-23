    private readonly ViewViewModelTypeResolver _viewViewModelTypeResolver;
    public App()
    {
        this.InitializeComponent();
        _viewViewModelTypeResolver = new ViewViewModelTypeResolver(this.GetType(), typeof(ViewModelBase));
    }
    //other methods are the same as Alexander's answer.
