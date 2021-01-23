	public partial class MainWindow : Window 
	{
		public MainWindow()
		{
			MyCommand = new RelayCommand(MyMethod);
			InitializeComponent();
			DataContext = this;
		}
		public RelayCommand MyCommand { get; set; }
		private void MyMethod()
		{
			MessageBox.Show("Click!");
		}
	}
	public class RelayCommand : ICommand
	{
		readonly Action<object> _execute;
		readonly Func<bool> _canExecute;
		public RelayCommand(Action execute) : this(execute, null) { }
		public RelayCommand(Action<object> execute) : this(execute, null) { }
		public RelayCommand(Action execute, Func<bool> canExecute)
		{
			if (execute == null)
				throw new ArgumentNullException("execute");
			_execute = p => execute();
			_canExecute = canExecute;
		}
		public RelayCommand(Action<object> execute, Func<bool> canExecute)
		{
			if (execute == null)
				throw new ArgumentNullException("execute");
			_execute = execute;
			_canExecute = canExecute;
		}
		public bool CanExecute(object parameter)
		{
			return _canExecute == null ? true : _canExecute();
		}
		public event EventHandler CanExecuteChanged 
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}
		public void Execute(object parameter)
		{
			_execute(parameter);
		}
	}
