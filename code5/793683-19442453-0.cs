            public class Ts: ICollection<T>
        {
            private Dictionary<string, T> inventory= new Dictionary<string,T>();
            //public void Add(string s, int q)
            //{
            //    inventory.Add(s, new T(s,q));
            //} 
            public void Add(T item)
            {
                inventory.Add(item.ItemName,item);
            }
            public void Add(string s, int q)
            {
                inventory.Add(s, new T(s, q));
            }
            public void Clear()
            {
                inventory.Clear();
            }
            public bool Contains(T item)
            {
                return inventory.ContainsValue(item);
            }
            public void CopyTo(T[] array, int arrayIndex)
            {
                inventory.Values.CopyTo(array, arrayIndex);
            }
            public int Count
            {
                get { return inventory.Count; }
            }
            public bool IsReadOnly
            {
                get { return false; }
            }
            public bool Remove(T item)
            {
                return inventory.Remove(item.ItemName);
            }
            public System.Collections.Generic.IEnumerator<T> GetEnumerator()
            {
                return inventory.Values.GetEnumerator();
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return inventory.Values.GetEnumerator();
            }
        } 
       class Program
       {
            Ts ts = new Ts { { "a", 1 }, { "b", 2 } };
            foreach (T t in ts)
            {
                Console.WriteLine("{0}:{1}",t.ItemName,t.Quantity);
            }
        }
