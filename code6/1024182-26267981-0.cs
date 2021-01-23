        SerialPort sp = (SerialPort)sender;
        string indata = sp.ReadExisting();
        Dispatcher.BeginInvoke(() =>
        {
           visor.Inlines.Add("Data Received:");
           visor.Inlines.Add(indata);
        }, null);
