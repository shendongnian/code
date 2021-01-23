    public class ConfigModelView:INotifyPropertyChanged
    { 
        public ConfigModelView()
        {
            GetServiceCollection=new ObservableCollection<string>();
        }
        bool isDataLoaded;
        public bool IsDataLoaded
        {
            get { return isDataLoaded; }
            set { isDataLoaded = value; OnPropertyChanged("IsDataLoaded"); }
        }
        MyCommand goCommand;
        public ICommand GoCommand
        {
            get{return goCommand ?? (goCommand=new MyCommand(()=>Command(),true));}
        }
        public ObservableCollection<string> GetServiceCollection{get;set;}
        
        void Command()
        {
            foreach (var item in _configServiceModel.CollectList)
            {
                GetServiceCollection.Add(item);
            }
            isDataLoaded = true;
            OnPropertyChanged("IsDataLoaded");
            goCommand.RaiseCanExecuteChanged();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
