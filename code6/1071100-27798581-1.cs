    public class SortChangedCommand : ICommand
    {
        MoviesViewModel _viewModel;
        public SortChangedCommand(MoviesViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public event EventHandler CanExecuteChanged;
        public void Execute(object parameter)
        {
            _viewModel.Sort(parameter as string);
        }
    }
