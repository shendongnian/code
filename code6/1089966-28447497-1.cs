    public class Logger<T> where T : IReadable
    {
        private readonly T _readable;
        public Logger<T>(T readable)
        {
            this._readable = readable;
        }
        public string Read()
        {
            return this._readable.Read();
        }
    }
