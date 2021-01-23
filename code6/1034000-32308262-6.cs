    public class LoggerPropertyProvider : IFixingRequired
    {
        private readonly string _value;
        public LoggerPropertyProvider(string value)
        {
            _value = value;
        }
        public override string ToString()
        {
            return _value;
        }
        object IFixingRequired.GetFixedObject()
        {
            return ToString();
        }
    }
