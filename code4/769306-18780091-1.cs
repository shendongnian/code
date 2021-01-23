    public class StreamWatcherEventArgs : EventArgs
    {
        public string Data { get; set; }
        public StreamWatcherEventArgs( string data )
        {
            Data = data;
        }
    }
