     public class MainViewModel : ViewModelBase
    {
        private static readonly Logger m_logger = LoggerProvider.GetLogger("MyPath.MainViewModel");
        private ISerializationService m_serializationService;
        private RelayCommand _trySaveCommand;
        public RelayCommand TrySaveCommand
        {
            get
            {
                return _trySaveCommand
                    ?? (_trySaveCommand = new RelayCommand(
                    () =>
                    {                        
                        Messenger.Default.Send(new NotificationMessage("SaveFile"));    
                    }));
            }
        }
        public MainViewModel()
        {
            m_serializationService = ServiceLocator.Current.GetInstance<ISerializationService>();
            Messenger.Default.Register<string>(this, "FileSaved", (pathIGotFromTheUser) =>
            {
                m_serializationService.SaveProject(pathIGotFromTheUser);
                //Give a feedback that everything has been correctly saved(for test purpose, a MessageBox.Show() )
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage("WentWell"));
            });           
        }
    
