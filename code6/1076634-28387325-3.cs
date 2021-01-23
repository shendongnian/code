    public class SimpleCommand : ICommand
    {
        public Predicate<object> CanExecutePredicate { get; set; }
        public Action<object> ExecuteAction { get; set; }
    
        public bool CanExecute(object parameter)
        {
            if (CanExecutePredicate != null)
                return CanExecutePredicate(parameter);
            return true; // if there is no can execute default to true
        }
    
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    
        public void Execute(object parameter)
        {
            if (ExecuteAction != null)
                ExecuteAction(parameter);
        }
    }
