    public class MainViewModel : GalaSoft.MvvmLight.ViewModelBase, IObserver<string>
    {
        #region Fields
        private string _lastSerialMessageReceived;
        private readonly ObservableCollection<string> _serialMessages = new ObservableCollection<string>(); 
        #endregion
        #region Constructors
        public MainViewModel()
        {
            var connection = new Solid.Arduino.SerialConnection("COM3", Solid.Arduino.SerialBaudRate.Bps_115200);
            var session = new Solid.Arduino.ArduinoSession(connection);
            session.CreateReceivedStringMonitor().Subscribe(this);
        }
        #endregion
        #region Public Interface
        public void OnCompleted()
        {
            throw new NotImplementedException();
        }
        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }
        public void OnNext(string value)
        {
            _serialMessages.Add(value);
            LastSerialMessageReceived = value;
        }
        public ObservableCollection<string> SerialMessages
        {
            get { return _serialMessages; }
        }
        public string LastSerialMessageReceived
        {
            get { return _lastSerialMessageReceived; }
            private set { Set(() => LastSerialMessageReceived, ref _lastSerialMessageReceived, value); }
        }
        #endregion
    }
