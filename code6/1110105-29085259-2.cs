    // This is what you need
    public IDictionaryEnumerator GetEnumerator()
    {
        return new MyDictionaryEnumerator(KeyValueEnumerator());
    }
    public class MyDictionaryEnumerator : IDictionaryEnumerator
    {
        public MyDictionaryEnumerator(IEnumerator<KeyValuePair<TKey, TValue>> enumerator)
        {
            Enumerator = enumerator;
        }
        public IEnumerator<KeyValuePair<TKey, TValue>> Enumerator;
        public DictionaryEntry Entry
        {
            get { return new DictionaryEntry(Enumerator.Current.Key, Enumerator.Current.Value); }
        }
        public object Key
        {
            get { return Enumerator.Current.Key; }
        }
        public object Value
        {
            get { return Enumerator.Current.Value; }
        }
        public object Current
        {
            get { return Entry; }
        }
        public bool MoveNext()
        {
            return Enumerator.MoveNext();
        }
        public void Reset()
        {
            Enumerator.Reset();
        }
    }
