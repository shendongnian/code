    public class ViewModel : INotifyPropertyChanged
    {
        public ICommand ExpandingCommand { get; set; }
        public ViewModel()
        {
            ExpandingCommand = new RelayCommand(ExecuteExpandingCommand, CanExecuteExpandingCommand);
        }
        private void ExecuteExpandingCommand(object obj)
        {
            Console.WriteLine(@"Expanded");
        }
        private bool CanExecuteExpandingCommand(object obj)
        {
            return true;
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
