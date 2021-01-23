    public class TestViewModel : ViewModelBase
    {
        #region OpenCommand
        private RelayCommand _testCommand;
        public RelayCommand TestCommand {
            get {
                return _testCommand = _testCommand 
                    ?? new RelayCommand(
                        this.ExecuteOpenCommand, 
                        this.CanOpenCommandExecute);
            }
        }
        private void ExecuteOpenCommand()
        {
            // do stuff
        }
        private bool CanOpenCommandExecute()
        {
            return true;
        }
        #endregion
    }
