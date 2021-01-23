            /// <summary> Returns an enumerator that iterates through the 
        /// ObservableExtendedCollection&lt;TValue&gt;. </summary>
        /// <returns> An enumerator for the 
        /// underlying ObservableExtendedCollection&lt;TKey,TValue&gt;. </returns>   
        public new IEnumerator<TValue> GetEnumerator()
        {
            return (IEnumerator<TValue>)base.GetEnumerator();
        }
        /// <summary> Returns an enumerator that iterates through the 
        /// System.Collections.Concurrent.ConcurrentDictionary&lt;TKey,TValue&gt;. </summary>
        /// <returns> An enumerator for the 
        /// System.Collections.Concurrent.ConcurrentDictionary&lt;TKey,TValue&gt;. </returns>
        /// <param name="collectionFlag">Flag indicates to return the collection enumerator</param>
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator(bool collectionFlag = true)
        {
            return this.collectionDictionary.GetEnumerator();
        }
