    public Queue(IEnumerable<T> collection)
    {
        _array = new T[_DefaultCapacity];
        _size = 0;
        _version = 0;
 
        using(IEnumerator<T> en = collection.GetEnumerator()) 
        {
            while(en.MoveNext()) {
                Enqueue(en.Current);
            }
        }            
    }
    
