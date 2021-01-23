    private string _dataReceived;
    private readonly object padLock = new object();
    private void _port_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        string newData = _port.ReadExisting();
     
        lock (padLock)
        {
            _dataReceived += newData;
        }
        new Action(() =>
        {
            Debug("Data received: {0}", newData);
            ParseAnswers();
        }).BeginInvoke(null, null);
    }
    private void ParseAnswers()
    {
        ...
        lock (padLock)
        {
            idx = _dataReceived.IndexOf(Environment.NewLine);
            if (idx != -1)
            {
                cmd = _dataReceived.Substring(0, idx);
                _dataReceived = _dataReceived.Substring(idx + 2);
            }
        }
        ...
    }
