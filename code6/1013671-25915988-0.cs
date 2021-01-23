    public class UberStrongTypedList<T> : IList<T>
    {
    	private readonly IList<T> _list = new List<T>();
    
        public void Add(T item)
        {
            if (item.GetType() == typeof (T))
                _list.Add(item);
            else
                ;//some error
        }
    
        public void Clear()
        {
            _list.Clear();
        }
        //SNIP...
    }
