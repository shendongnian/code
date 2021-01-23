    public class DelegateCommand<T> : ICommand where T : class
	{
		private readonly Action<T> _command;
		private readonly Func<T, bool> _canExecute;
		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}
		public DelegateCommand(Action<T> command, Func<T, bool> canExecute = null)
		{
			if (command == null)
				throw new ArgumentNullException();
			_canExecute = canExecute;
			_command = command;
		}
		public void Execute(object parameter)
		{
			_command(parameter as T);
		}
		public bool CanExecute(object parameter)
		{
			return _canExecute == null || _canExecute(parameter as T);
		}
	}
