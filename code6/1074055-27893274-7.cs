    public interface ITextBuffer
    {
        void Delete();
        void Delete(int offset, int length);
    
        void Append(string content);
        void Append(string content, int offset);
    
        string GetCurrentValue();
    
        event EventHandler<string> BufferAppendedHandler;
    }
    
    internal class MyTextBuffer : ITextBuffer
    {
        #region Implementation of ITextBuffer
    
        private readonly StringBuilder _buffer = new StringBuilder();
    
        public void Delete()
        {
            _buffer.Clear();
        }
    
        public void Delete(int offset, int length)
        {
            _buffer.Remove(offset, length);
        }
    
        public void Append(string content)
        {
            _buffer.Append(content);
    
            var @event = BufferAppendedHandler;
            if (@event != null)
                @event(this, content);
        }
    
        public void Append(string content, int offset)
        {
            if (offset == _buffer.Length)
            {
                _buffer.Append(content);
            }
            else
            {
                _buffer.Insert(offset, content);
            }
        }
    
        public string GetCurrentValue()
        {
            return _buffer.ToString();
        }
    
        public event EventHandler<string> BufferAppendedHandler;
    
        #endregion
    }
