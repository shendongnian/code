    public class Page1VM : ViewModelBase
    {
        public RelayCommand SetTextCommand { get; private set; }
        public RelayCommand CancelCommand { get; private set; }
        public Page1VM()
        {
            SetTextCommand = new RelayCommand(ExecuteSetText);
            CancelCommand = new RelayCommand(ExecuteCancel, CanExecuteCancel);
        }
        private string _displayText="";
        public string DisplayText
        {
            get { return _displayText; }
            set
            {
                _displayText = value;
                RaisePropertyChanged("DisplayText");
                RaisePropertyChanged("CanCancel");
                // Raise the CanExecuteChanged event of CancelCommand
                // This makes the UI reevaluate the CanExecuteCancel
                // Set a breakpoint in CanExecuteCancel method to make
                // sure it is hit when changing the text
                CancelCommand.RaiseCanExecuteChanged();                
            }
        }
        private bool CanExecuteCancel()
        {
            // You can simplify the statement like this:
            return DisplayText != "";
        }
        private void ExecuteCancel()
        {
            DisplayText = "";
        }
        private void ExecuteSetText()
        {
            DisplayText = "Hello";
        }
    }
