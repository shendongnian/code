    public interface ITextBuffer
    {
        void Clear();
        void Append(string content);
    
        string GetCurrentValue();
        event EventHandler<string> BufferAppendedHandler;
    }
    internal class MyTextBuffer : ITextBuffer
    {
        #region Implementation of ITextBuffer
        private readonly StringBuilder _buffer= new StringBuilder();
        public void Clear()
        {
            _buffer.Clear();
        }
        public void Append(string content)
        {
            _buffer.Append(content);
            var @event = BufferAppendedHandler;
            if (@event != null)
                @event(this, content);
        }
        public string GetCurrentValue()
        {
            return _buffer.ToString();
        }
        public event EventHandler<string> BufferAppendedHandler;
        #endregion
    }
