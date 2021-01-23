	public MainWindow()
	{
		InitializeComponent();
		DataContext = this;
		for (int i = 0; i < 10; i++)
		{
			Items.Add(new VM() { Text1=i.ToString(), Text2 = (i+100).ToString()});
		}
		FocusCommand = new MyCommand(o =>
		{
			var dg = o as DataGrid;
			if (dg != null) {
                 dg.Focus();
			     FocusedCell = new DataGridCellInfo(
                       dg.Items[FocusedRowIndex], dg.Columns[FocusedColumnIndex]);
            }
		});
	}
	//Items Observable Collection
	public ObservableCollection<VM> Items { get { return _myProperty; } }
	private ObservableCollection<VM> _myProperty = new ObservableCollection<VM>();
	//FocusedCell Dependency Property
	public DataGridCellInfo FocusedCell
	{
		get { return (DataGridCellInfo)GetValue(FocusedCellProperty); }
		set { SetValue(FocusedCellProperty, value); }
	}
	public static readonly DependencyProperty FocusedCellProperty =
		DependencyProperty.Register("FocusedCell", typeof(DataGridCellInfo), typeof(MainWindow), new UIPropertyMetadata(null));
	//FocusCommand Dependency Property
	public MyCommand FocusCommand
	{
		get { return (MyCommand)GetValue(FocusCommandProperty); }
		set { SetValue(FocusCommandProperty, value); }
	}
	public static readonly DependencyProperty FocusCommandProperty =
		DependencyProperty.Register("FocusCommand", typeof(MyCommand), typeof(MainWindow), new UIPropertyMetadata(null));
	//FocusedRowIndex Dependency Property
	public int FocusedRowIndex
	{
		get { return (int)GetValue(FocusedRowIndexProperty); }
		set { SetValue(FocusedRowIndexProperty, value); }
	}
	public static readonly DependencyProperty FocusedRowIndexProperty =
		DependencyProperty.Register("FocusedRowIndex", typeof(int), typeof(MainWindow), new UIPropertyMetadata(0));
	//FocusedColumnIndex Dependency Property
	public int FocusedColumnIndex
	{
		get { return (int)GetValue(FocusedColumnIndexProperty); }
		set { SetValue(FocusedColumnIndexProperty, value); }
	}
	public static readonly DependencyProperty FocusedColumnIndexProperty =
		DependencyProperty.Register("FocusedColumnIndex", typeof(int), typeof(MainWindow), new UIPropertyMetadata(0));
