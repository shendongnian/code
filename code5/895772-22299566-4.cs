    public MainWindow()
    {
            InitializeComponent();
            DataContext = this;
            Items.Add(new ListItemVm { ItemText = "something" } );
            Items.Add(new ListItemVm { ItemText = "something" } );
            Items.Add(new ListItemVm { ItemText = "something" } );
            Items.Add(new ButtonVm { ButtonText = "click here" } );
    }
	private ObservableCollection<DependencyObject> _items = new ObservableCollection<DependencyObject>();
	public ObservableCollection<DependencyObject> Items { get { return _items; } }
