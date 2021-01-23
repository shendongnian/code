    public class CustomComparerDictionaryCreationConverter<T> : CustomCreationConverter<IDictionary>
    {
        private IEqualityComparer<T> comparer;
        public CustomComparerDictionaryCreationConverter(IEqualityComparer<T> comparer)
        {
            if (comparer == null)
                throw new ArgumentNullException("comparer");
            this.comparer = comparer;
        }
        
        public override bool CanConvert(Type objectType)
        {
            return HasCompatibleInterface(objectType)
                && HasCompatibleConstructor(objectType);
        }
        
        private static bool HasCompatibleInterface(Type objectType)
        {
            return objectType.GetInterfaces()
                .Where(i => HasGenericTypeDefinition(i, typeof(IDictionary<,>)))
                .Where(i => typeof(T).IsAssignableFrom(i.GetGenericArguments().First()))
                .Any();
        }
        
        private static bool HasGenericTypeDefinition(Type objectType, Type typeDefinition)
        {
            return objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeDefinition;
        }
    
        private static bool HasCompatibleConstructor(Type objectType)
        {
            return objectType.GetConstructor(new Type[] { typeof(IEqualityComparer<T>) }) != null;
        }
        
        public override IDictionary Create(Type objectType)
        {
            return Activator.CreateInstance(objectType, comparer) as IDictionary;
        }
    }
