    class ViewModel
    {
        public ICommand CommitCommand{ get; private set; }
        
        public ViewModel()
        {
            CommitCommand = new RelayCommand(Commit, CanCommit);
        }
        private void Commit(object parameter)
        {
            // button click handler
        }
        private bool CanCommit(object parameter)
        {
            // check: view model has errors
        }
    }
