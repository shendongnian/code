    public class SomeViewModel: BaseViewModel
    {
        public IMessenger Messenger { get { return base.MessengerInstance; } }
        public SomeViewModel()
        {
            Initialize(); 
        }
        public void Initialize()
        {
            RegisterMessengers();
        }
        public void RegisterMessengers()
        {
             Messenger.Register<string>(
                this, "TokenRefresh", u => LoadData(u));
        }
        public async void LoadData(string u)
        {
            //load data, ex. add items to list
        }
        private RelayCommand _refreshCommand;
        /// <summary>
        /// Gets the RefreshCommand.
        /// </summary>
        public RelayCommand RefreshCommand
        {
            get
            {
                return _refreshCommand
                    ?? (_refreshCommand = new RelayCommand(() => LoadData()));
            }
        }
    }
