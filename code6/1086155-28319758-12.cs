    void OnPortDataReceived(object sender,
        SerialDataReceivedEventArgs e)
    {
        if (e.EventType == SerialData.Chars)
            _receive.Set();
    }
