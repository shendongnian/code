    class LinkedHashSet<T>
    {
        private LinkedList<T> _list;
        private Dictionary<T, LinkedListNode<T>> _containedElements
    
        public void Add(T value)
        {
            LinkedListNode<T> newNode = _list.AddLast(value);
            _containedElements[value] = newNode;
        }
        public void Remove(T value)
        {
            LinkedListNode<T> node = _containedElements[value];
            _containedElements.Remove(value);
            _list.Remove(node);
        }
        public bool Contains(T value)
        {
            return _containedElements.ContainsKey(value);
        }
    }
