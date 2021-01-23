    public class ProjectedKeyCollection<TKey, TItem> : KeyedCollection<TKey, TItem>
    {
        private readonly Func<TItem, TKey> keySelector;
        public ProjectedKeyCollection(Func<TItem, TKey> keySelector)
        {
            this.keySelector = keySelector;
        }
        protected override TKey GetKeyForItem(TItem item)
        {
            return keySelector(item);
        }
    }
