    internal sealed class OriginalToConcreteMessageParserBarMessageParser : OriginalToConcreteMessageParser
    {
        public ConcreteMessage Serialize(OriginalMessage originalMessage)
        {
            Func<OriginalMessage, ConcreteMessage> baz = message =>
            {
                ConcreteMessage bar = ToBar(message);
                return bar;
            };
            return base.Serialize(originalMessage, baz);
        }
    }
