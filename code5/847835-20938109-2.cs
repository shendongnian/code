    public class ViewModelBase:INotifyPropertyChanged
    {
        private ICommand _clickCommand;
        
        public ICommand ClickCommand
        {
            get
            {
                return _clickCommand ?? (_clickCommand = new CommandHandler(MyAction,()=>true));
            }
        }
        public void MyAction(object obj)
        {
            if(obj == null )
                return;
            //if CommandParameter is Cild1VM
            if (obj.ToString() == "Child1VM")
                CurrentViewModel = new Child1ViewModel();
            //if CommandParameter is Cild1VM
            else if (obj.ToString() == "Child2VM")
                CurrentViewModel = new Child2ViewModel();
        }
        ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                if (_currentViewModel == value)
                    return;
                _currentViewModel = value;
                this.RaiseNotifyPropertyChanged("CurrentViewModel");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        void RaiseNotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
    public class Child1ViewModel : ViewModelBase
    { }
    public class Child2ViewModel : ViewModelBase
    { } 
