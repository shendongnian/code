    /// <summary>Dictionary changed event handler</summary>
    /// <param name="sender">The dictionary</param>
    /// <param name="e">The event arguments</param>
    public delegate void NotifyDictionaryChangedEventHandler(object sender, NotifyDictionaryChangedEventArgs e);
    public class CollectionDictionary<TKey, TValue> : ObservableCollection<TValue>
    {
        #region Fields
        private ConcurrentDictionary<TKey, TValue> collectionDictionary = 
            new ConcurrentDictionary<TKey, TValue>();
        #endregion
        /// <summary>
        /// Initializes a new instance of the CollectionDictionary class
        /// </summary>
        public CollectionDictionary()
        {
        }
        /// <summary>
        /// Initializes a new instance of the CollectionDictionary class
        /// </summary>
        /// <param name="collectionDictionary">A dictionary</param>
        public CollectionDictionary(Dictionary<TKey, TValue> collectionDictionary)
        {
            for (int i = 0; i < collectionDictionary.Count; i++)
            {
                this.Add(collectionDictionary.Keys.ToList()[i], collectionDictionary.Values.ToList()[i]);                
            }
        }
        /// <summary>
        /// Initializes a new instance of the CollectionDictionary class
        /// </summary>
        /// <param name="collectionDictionary">A concurrent dictionary</param>
        public CollectionDictionary(ConcurrentDictionary<TKey, TValue> collectionDictionary)
        {
            this.collectionDictionary = collectionDictionary;
        }
        #region Events
        /// <summary>The dictionary has changed</summary>
        public event NotifyDictionaryChangedEventHandler DictionaryChanged;
        #endregion
        #region Indexers
        /// <summary> Gets the value associated with the specified key. </summary>
        /// <param name="key"> The key of the value to get or set. </param>
        /// <returns> Returns the Value property of the System.Collections.Generic.KeyValuePair&lt;TKey,TValue&gt;
        /// at the specified index. </returns>
        public TValue this[TKey key] 
        {
            get 
            {
                TValue tValue;
                if (this.collectionDictionary.TryGetValue(key, out tValue) && (key != null))
                {
                    return this.collectionDictionary[key];
                }
                else
                {
                    return tValue;
                }
            }
            ////set
            ////{
            ////    this.collectionDictionary[key] = value;
            ////    string tKey = key.ToString();
            ////    string tValue = this.collectionDictionary[key].ToString();
            ////    KeyValuePair<TKey, TValue> genericKeyPair = new KeyValuePair<TKey, TValue>(key, value);
            ////    List<KeyValuePair<TKey, TValue>> keyList = this.collectionDictionary.ToList();
            ////    for (int i = 0; i < keyList.Count; i++)
            ////    {
            ////        if (genericKeyPair.Key.ToString() == keyList[i].Key.ToString())
            ////        {
            ////            RemoveAt(i, String.Empty);
            ////            Insert(i, value.ToString(), String.Empty);
            ////        }
            ////    }
            ////} 
        }
        
        /// <summary>
        /// Gets the value associated with the specific index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The value at that index</returns>
        public new TValue this[int index]
        {
            get
            {
                if (index > (this.Count - 1))
                {
                    return default(TValue);
                }
                else
                {
                    return this.collectionDictionary.ToList()[index].Value;
                }
            }
        }
        #endregion
        /// <summary>
        /// Dictionary has changed. Notify any listeners.
        /// </summary>
        /// <param name="e">Evevnt arguments</param>
        protected virtual void OnDictionaryChanged(NotifyDictionaryChangedEventArgs e)
        {
            if (this.DictionaryChanged != null)
            {
                this.DictionaryChanged(this, e);
            }
        }
