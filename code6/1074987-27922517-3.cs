    public class SaveChangesCommand : ICommand
    {
        private MainViewModel _viewModel;
        public SaveChangesCommand(MainViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public bool CanExecute(object parameter)
        {
            //People should be an ObservableCollection<Person> in your view model.
            return _viewModel.People.Any(x => x.IsDirty);
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public void Execute(object parameter)
        {
            _viewModel.SaveChanges();
        }
    }
