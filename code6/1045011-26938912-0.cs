    public class OuterDictionaryObject
    {
        private Dictionary<int, ValueDictionaryObject> outerDict;
        public float GetTotalValueForSomeKey(int key )
        {
            ValueDictionaryObject vdo;
            lock (((ICollection)this.outerDict).SyncRoot)
            {
                vdo = outerDict[key];
            }
            return vdo.GetTotalValue();
        }
    }
