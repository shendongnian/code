    public class ViewModel : INotifyPropertyChanged
    {
        private Model _model;
        private ICommand _actionCommand;
    
        public ViewModel(Model model)
        {
            _model = model;
            _actionCommand = new RelayCommand(ExecuteAction);
        }
    
        public ICommand ActionCommand
        {
           get { return _actionCommand; }      
        }
    
        private void ExecuteAction()
        {
           _model.Action();
        }
    }
