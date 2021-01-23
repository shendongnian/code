	public class MyCommand : ICommand
	{
		public bool CanExecute(object parameter)
		{
			//here you can change the enabled/disabled state of 
			//any button that bind to this command
			return true;		
		}
		public event EventHandler CanExecuteChanged;
		public void Execute(object parameter)
		{
		}
	}
