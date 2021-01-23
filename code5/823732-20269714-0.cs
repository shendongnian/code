    public class SomeHelperClass
    {
        private static readonly ConcurrentDictionary<Type, bool> messageAttributesCache = new ConcurrentDictionary<Type, bool>();
        private static readonly Type messageAttributeType = typeof(MessageAttribute);
        public static bool IsMessageAttributeDefined(Type type)
        {
            bool isDefined = false;
            if (messageAttributesCache.TryGetValue(type, out isDefined))
            {
                return isDefined;
            }
            isDefined = type.IsDefined(messageAttributeType, false);
            return messageAttributesCache[type] = isDefined;
        }
    }
