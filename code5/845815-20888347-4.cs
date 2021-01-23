    public class ConfigModelView
    {
        public ConfigModelView()
        {
            GetServiceCollection = new ObservableCollection<string>();
        }
        bool isDataLoaded = false;
        
        MyCommand goCommand;
        public ICommand GoCommand
        {
            get { return goCommand ?? (goCommand = new MyCommand(() => OnGoCommand(), () => !isDataLoaded)); }
        }
        public ObservableCollection<string> GetServiceCollection { get; set; }
        void OnGoCommand()
        {
            GetServiceCollection.Clear();
            foreach (var item in _configServiceModel.CollectList)
            {
                GetServiceCollection.Add(item);
            }
            isDataLoaded = true;
            goCommand.RaiseCanExecuteChanged();
        }
    }
        
