    public class StringEventArgs : EventArgs
    {
        public StringEventArgs(string message) { this.Message = message; }
        public string Message { get; private set; }
    }
