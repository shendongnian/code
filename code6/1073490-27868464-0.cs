    public class BroadcastDictionary<TKey, TItem> : Dictionary<TKey, TItem> where TItem : new()
    {
        public new string this[TKey key]
        {
            get
            {
                if (!base.ContainsKey(key))
                {
                    try
                    {
                        //Construct the object and put it
                        // into the collection:
                        var item = new TItem();
                        base.Add(key, item);
                    }
                    catch
                    {
                        ;// Log the lazy object generation failure
                    }
                }
                if (base.ContainsKey(key))
                    return base[key].ToString();
                else
                    throw new Exception("BroadcastDictionary value object lazy load failure.");
            }
        }
    }
