	public MainWindow()
	{
		InitializeComponent();
        var vm = new MainVm();
        vm.Login = new LoginVm();
        vm.Login.Username = "please enter username";
        DataContext = vm;
	}
