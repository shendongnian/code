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
            if (HasCompatibleConstructor(objectType))
                return true;
            return base.CanConvert(objectType);
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
