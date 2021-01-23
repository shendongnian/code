    public static class MyCommands
    {
        static MyCommands()
        {
            AddEppCommand = new SimpleDelegateCommand(p =>
            {
                var menuItem = p as MenuItem;
                //Console.WriteLine(e.OriginalSource.ToString());
                //Console.WriteLine(e.Source.ToString());
                Console.WriteLine("EP");
            });
        }
        public static ICommand AddEppCommand { get; set; }
    }
    public class SimpleDelegateCommand : ICommand
    {
        public SimpleDelegateCommand(Action<object> executeAction)
        {
            _executeAction = executeAction;
        }
        private Action<object> _executeAction;
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public event EventHandler CanExecuteChanged;
        public void Execute(object parameter)
        {
            _executeAction(parameter);
        }
    }
