    public class ViewModel : INotifyPropertyChanged
    {
        // declare the command
        public ICommand UpdateCommand { get; set; }
        public ViewModel()
        {   // initialize the command
            UpdateCommand = new RelayCommand(ExecuteUpdateCommand, CanExecuteUpdateCommand);
        }
        #region UpdateCommand callbacks
        private bool CanExecuteUpdateCommand(object obj)
        {
            if (SelectedUser == null) return false;
            return true;
        }
        private void ExecuteUpdateCommand(object obj)
        {
            Console.WriteLine("Executing the command");
        }
        #endregion // end of UpdateCommand callbacks
        private User _selectedUser;
        public User SelectedUser
        {
            [DebuggerStepThrough]
            get { return _selectedUser; }
            [DebuggerStepThrough]
            set
            {
                if (value != _selectedUser)
                {
                    _selectedUser = value;
                    OnPropertyChanged("SelectedUser");
                }
            }
        }
        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            var handler = System.Threading.Interlocked.CompareExchange(ref PropertyChanged, null, null);
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion
    }
