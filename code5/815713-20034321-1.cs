    public class MyViewModel : INotifyPropertyChanged
    {
        private readonly MyModel model;
    
        private string mdbDir;
        public string MdbDir
        {
            get
            {
                return this.mdbDir;
            }
            set
            {
                this.mdbDir = value;
                RaisePropertyChanged("MdbDir");
            }
        }
    
        private List<string> mdbTblList;
        public List<string> MdbTblList
        {
            get
            {
                return this.mdbTblList;
            }
            set
            {
                this.mdbTblList = value;
                RaisePropertyChanged("MdbTblList");
            }
        }
    
        private DelegateCommand updateMdbTblListCommand;
        public ICommand UpdateMdbTblListCommand
        {
            get
            {
                return this.updateMdbTblListCommand ??
                        (this.updateMdbTblListCommand = new DelegateCommand(this.UpdateMdbTblList));
            }
        }
    
        public MyViewModel()
        {
            // This would idealy be injected via the constructor
            this.model = new MyModel();
        }
    
        private void UpdateMdbTblList(object obj)
        {
            var param = obj as string;
            this.MdbTblList = this.model.ReturnMdbTblList(param);
        }
    
        #region [ INotifyPropertyChanged ]
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        [NotifyPropertyChangedInvocator]
        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        #endregion
    }
    
    public class MyModel
    {
        public List<string> ReturnMdbTblList(string mdbDir)
        {
            // Do soemthing
            return new List<string>();
        }
    }
    
    public class DelegateCommand : ICommand
    {
        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _execute;
    
        public event EventHandler CanExecuteChanged;
    
        public DelegateCommand(Action<object> execute)
            : this(execute, null)
        {
        }
    
        public DelegateCommand(Action<object> execute,
                        Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
    
        public bool CanExecute(object parameter)
        {
            return this._canExecute == null || this._canExecute(parameter);
        }
    
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    
        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }
