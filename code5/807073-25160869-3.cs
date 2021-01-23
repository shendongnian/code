    public class CustomJsonWriter : JsonTextWriter
    {
        private readonly Dictionary<string, string> _backwardMappings;
        public CustomJsonWriter(TextWriter writer, Dictionary<string, string> backwardMappings)
            : base(writer)
        {
            _backwardMappings = backwardMappings;
        }
        public override void WritePropertyName(string name)
        {
            base.WritePropertyName(_backwardMappings[name]);
        }
    }
    public class CustomJsonReader : JsonTextReader
    {
        private readonly Dictionary<string, string> _forwardMappings;
        public CustomJsonReader(TextReader reader, Dictionary<string, string> forwardMappings )
            : base(reader)
        {
            _forwardMappings = forwardMappings;
        }
        public override object Value
        {
            get
            {
                if (TokenType != JsonToken.PropertyName)
                    return base.Value;
                return _forwardMappings[base.Value.ToString()];
            }
        }
    }
