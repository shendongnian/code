        /// <summary> Adds a key/value pair to the 
        /// System.Collections.Concurrent.ConcurrentDictionary&lt;TKey,TValue&gt;
        /// if the key does not already exist, or updates a key/value pair in the 
        /// System.Collections.Concurrent.ConcurrentDictionary&lt;TKey,TValue&gt;
        /// if the key already exists. </summary>
        /// <param name="key"> The key to be added or whose value should be updated </param>
        /// <param name="addValueFactory">The function used to generate a value for an absent key</param>
        /// <param name="updateValueFactory">The function used to generate a new value for an 
        /// existing key based on the key's existing value</param>
        /// <returns> The new value for the key. This will be either be the result of addValueFactory
        /// (if the key was absent) or the result of updateValueFactory (if the key was
        /// present). </returns>
        internal TValue AddOrUpdate(TKey key, Func<TKey, TValue> addValueFactory, Func<TKey, TValue, TValue> updateValueFactory)
        {
            TValue value;
            value = this.collectionDictionary.AddOrUpdate(key, addValueFactory, updateValueFactory);
            if (this.collectionDictionary.TryGetValue(key, out value))
            {
                ArrayList valueList = new ArrayList() { value };
                ArrayList keyList = new ArrayList() { key };
                NotifyDictionaryChangedEventArgs e = new NotifyDictionaryChangedEventArgs(
                    NotifyCollectionChangedAction.Add,
                    valueList,
                    keyList);
                this.Add(value, string.Empty);
                this.OnDictionaryChanged(e);
            }
            return value;
        }
