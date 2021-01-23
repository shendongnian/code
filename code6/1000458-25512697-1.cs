    public class XDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        public new TValue this[TKey key] 
        {
            get { return base[key]; }   // get item calling the base implementation
            set 
            { 
                   if(value.Equals(default(TValue))) // additional logic (OPTIONAL)
                       return;                       // Don't add default values
                   base[key] = value; // set item calling the base implementation 
            }  
        }
    }
