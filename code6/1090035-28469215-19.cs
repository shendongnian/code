    using GalaSoft.MvvmLight.CommandWpf
    public MainWindow()
    {
		InitializeComponent();
		CommandOne = new RelayCommand<string>(executeCommandOne);
		CommandTwo = new RelayCommand(executeCommandTwo);
	}
	public RelayCommand<string> CommandOne { get; set; }
	public RelayCommand CommandTwo { get; set; }
	private void executeCommandOne(string param)
	{
		// Do something here.
	}
	private void executeCommandTwo()
	{
		// Do something here.
	}
