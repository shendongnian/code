    class ReorderingDictionary : IDictionary<int, OrderItem>
        {
    
            private SortedList<int, OrderItem> sortedList = new SortedList<int, OrderItem>();
    
            public void Add(int key, OrderItem value)
            {
                value.IneedToBeReordered += value_IneedToBeReordered;
                sortedList.Add(key, value);
            }
    
            void value_IneedToBeReordered(object sender, ReOrderMeEventArgs e)
            {
                sortedList.Remove(e.OldKey);
                OrderItem item = (OrderItem)sender;
                sortedList.Add(item.Ord, item);
            }
    
            public bool ContainsKey(int key)
            {
                return sortedList.ContainsKey(key);
            }
    
            public ICollection<int> Keys
            {
                get { return sortedList.Keys; }
            }
    
            public bool Remove(int key)
            {
                return sortedList.Remove(key);
            }
    
            public bool TryGetValue(int key, out OrderItem value)
            {
                return sortedList.TryGetValue(key, out value);
            }
    
            public ICollection<OrderItem> Values
            {
                get { return sortedList.Values; }
            }
    
            public OrderItem this[int key]
            {
                get
                {
                    return sortedList[key];
                }
                set
                {
                    sortedList[key] = value;
                }
            }
    
            public void Add(KeyValuePair<int, OrderItem> item)
            {
                item.Value.IneedToBeReordered += value_IneedToBeReordered;
                sortedList.Add(item.Key, item.Value);
            }
    
            public void Clear()
            {
                sortedList.Clear();
            }
    
            public bool Contains(KeyValuePair<int, OrderItem> item)
            {
                return sortedList.ContainsKey(item.Key) && sortedList[item.Key] == item.Value;
            }
    
            public void CopyTo(KeyValuePair<int, OrderItem>[] array, int arrayIndex)
            {
                throw new NotImplementedException();
            }
    
            public int Count
            {
                get { return sortedList.Count; }
            }
    
            public bool IsReadOnly
            {
                get { throw new NotImplementedException(); }
            }
    
            public bool Remove(KeyValuePair<int, OrderItem> item)
            {
                return sortedList.Remove(item.Key);
            }
    
            public IEnumerator<KeyValuePair<int, OrderItem>> GetEnumerator()
            {
                return sortedList.GetEnumerator();
            }
    
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return sortedList.GetEnumerator();
            }
        }
    
    
        class OrderItem
        {
            private int ord;
    
            public int Ord
            {
                get { return ord; }
                set
                {
                    int oldKey = ord;
                    ord = value;
                    if (IneedToBeReordered != null)
                    {
                        IneedToBeReordered(this, new ReOrderMeEventArgs(oldKey));
                    }
                }
            }
    
            public event EventHandler<ReOrderMeEventArgs> IneedToBeReordered;
        }
    
        class ReOrderMeEventArgs : EventArgs
        {
            public int OldKey { get; private set; }
    
            public ReOrderMeEventArgs(int oldKey)
            {
                this.OldKey = oldKey;
            }
        }
