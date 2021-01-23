    public sealed class DerpCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly ViewModel _viewModel;
        private int _count = 0;
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            _viewModel.Derper = _count % 2 == 0 ?
                (object)new Derp() 
                    { Herp = "Derped " + (++_count / 2 + 1) + " times." } :
                new Herp() 
                    { Derp = "Herped " + (_count++ / 2 + 1) + " times." };
        }
        public DerpCommand(ViewModel viewModel)
        {
            this._viewModel = viewModel;
        }
    }
