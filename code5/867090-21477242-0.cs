    internal abstract class OriginalToConcreteMessageParser : IMessageParser<OriginalMessage, ConcreteMessage>
    {
        public virtual ConcreteMessage Serialize(OriginalMessage originalMessage, Func<OriginalMessage, ConcreteMessage> baz)
        {
            return baz(originalMessage);
        }
    }
