    public MainWindow()
    {
    
        InitializeComponent();
        if (DesignerProperties.GetIsInDesignMode(this))
        {
            this.DataContext = new ParentViewModel();
        }
        else
        {      
             IUnityContainer container = UnityFactory.Retrieve();
    
             ParentViewModel parentVM = container.Resolve<ParentViewModel>();
             container.RegisterInstance<ParentViewModel>(parentVM);
    
             this.DataContext = parentVM;
    
         }
    }
