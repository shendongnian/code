    public void Insert(int index, T item)
    {
        if (index > this._size) // here you get an exception
           throw new ArgumentOutOfRangeException();
        
        if (this._size == this._items.Length)    
            this.EnsureCapacity(this._size + 1); // resize items
        
        if (index < this._size)    
            Array.Copy(_items, index, this._items, index + 1, this._size - index);
        
        this._items[index] = item;
        this._size++;
        this._version++;
    }
   
