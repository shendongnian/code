    class Connection : MarshalByRefObject
    {
        event ReceivedDataEventHandler ReceivedData;
        void Send(byte[] b)
        {
            // ...
        }
    }
    class ReceivedDataEventArgs : MarshalByRefObject
    {
        public string Data { get; }
    }
    delegate void ReceivedDataEventHandler(object sender, ReceivedDataEventArgs e);
