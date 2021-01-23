    public class ObservableSerialPort_byte : ObservableSerialPort<byte>
    {
        public ObservableSerialPort_byte(string portName, int baudRate = 9600, Parity parity = Parity.None, int dataBits = 8, StopBits stopBits = StopBits.One)
        : base(portName, baudRate, parity, dataBits, stopBits) { }
    
        public override IDisposable Subscribe(IObserver<byte> observer)
        {
