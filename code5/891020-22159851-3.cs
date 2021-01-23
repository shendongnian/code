    public class TestViewModel : ViewModelBase
    {
        private RelayCommand _testCommand;
        public RelayCommand TestCommand {
            get {
                return _testCommand = _testCommand 
                    ?? new RelayCommand(
                        this.ExecuteOpenCommand, 
                        this.CanOpenCommandExecute);
            }
        }
        public bool TestBoolean { get; set; }
    }
