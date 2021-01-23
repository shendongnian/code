    public class XDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        public new TValue this[TKey Key] 
        {
            get { return base[Key]; }   // get item calling the base implementation
            set { base[Key] = value; }  // set item calling the base implementation 
        }
    }
