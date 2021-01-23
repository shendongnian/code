        public partial class BidirectionalDictionary<TKey, TValue> : IDeserializationCallback
        {
            public void OnDeserialization(object sender)
            {
                this.forwardMap.OnDeserialization(sender);
                foreach (KeyValuePair<TKey, TValue> entry in forwardMap)
                {
                    this.inverseMap.Add(entry.Value, entry.Key);
                }
                // inverseInstance will no longer be able to be read-only sicne it is being allocated in a post-deserialization callback.
                this.inverseInstance = new BidirectionalDictionary<TValue, TKey>(this);
            }
    (You could do it in an [`[OnDeserialied]`](https://msdn.microsoft.com/en-us/library/system.runtime.serialization.ondeserializedattribute(v=vs.110).aspx) method instead if you prefer.)
