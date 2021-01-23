    public class Logger<T> : IReadable where T : IReadable, new()
    {
        private readonly T _readable;
        public Logger<T>()
        {
            this._readable = new T();
        }
        public string Read()
        {
            return this._readable.Read();
        }
    }
