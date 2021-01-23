    using Microsoft.Practices.Prism.Commands;
    // With params.
    public DelegateCommand<string> CommandOne { get; set; }
    // Without params.
    public DelegateCommand CommandTwo { get; set; }
	public MainWindow()
	{
		InitializeComponent();
        // Must initialize the DelegateCommands here.
		CommandOne = new DelegateCommand<string>(executeCommandOne);
		CommandTwo = new DelegateCommand(executeCommandTwo);
	}
	private void executeCommandOne(string param)
	{
		// Do something here.
	}
	private void executeCommandTwo()
	{
		// Do something here.
	}
