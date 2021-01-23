    public void Add(T item)
    {
        if (this._size == this._items.Length)    
            this.EnsureCapacity(this._size + 1); // resize items array
        
        this._items[this._size++] = item; // change size
        this._version++;
    }
