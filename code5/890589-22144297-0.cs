	public class CustomCommand : ICommand
	{
		Action _exec;
		public CustomCommand(Action exec)
		{
			_exec = exec;
		}
		public void Execute(object parameter)
		{
			if (_exec != null) _exec();
		}
		public bool CanExecute(object parameter)
		{
			return true;
		}
		public event EventHandler CanExecuteChanged;
	}
