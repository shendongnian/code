    internal sealed class OriginalToConcreteMessageParserFooMessageParser : OriginalToConcreteMessageParser
    {
        public ConcreteMessage Serialize(OriginalMessage originalMessage)
        {
            Func<OriginalMessage, ConcreteMessage> baz = message =>
                {
                    ConcreteMessage foo = ToFoo(message);
                    return foo;
                };
            return base.Serialize(originalMessage, baz);
        }
    }
