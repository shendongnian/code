      internal class MainWindowViewModel : INotifyPropertyChanged
      {
        #region Constructor
        public MainWindowViewModel() 
        {
            ClientStateManager = new ClientStateManager();
        }
        #endregion
        #region Public Properties  
        public ClientStateManager ClientStateManager { get; private set; }
        #endregion
      }
