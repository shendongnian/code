    public class MainWindow : Window
    {
        // ...
        
        public ConnectionStatus CurrentConnectionStatus
        {
            get { return _myConnectionStatus; }
            // set is optional
        }
    }
