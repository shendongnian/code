    public class ObservableDictionary <TKey, TValue> :
            IDictionary<TKey, TValue>,
            ICollection<KeyValuePair<TKey, TValue>>,
            IEnumerable<KeyValuePair<TKey, TValue>>,
            IDictionary,
            ICollection,
            IEnumerable,
            ISerializable,
            IDeserializationCallback,
            INotifyCollectionChanged,
            INotifyPropertyChanged{ }
