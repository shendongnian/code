    ICollection<T> c = collection as ICollection<T>;
    if( c != null) {
        int count = c.Count;
        if (count == 0)
        {
            _items = _emptyArray;
        }
        else {
            _items = new T[count];
            c.CopyTo(_items, 0);  /* it's possible there are now fewer elements in c */
            _size = count;
        }
    } 
