    class Bag<T>
    {
         private readonly List<T> _items = new List<T>();
         public void AddSlot(T item)
         {
             _items.Add(item);
         }
    }
