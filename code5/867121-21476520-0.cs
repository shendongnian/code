    public void TrimExcess()
    {
        int num = (int) (this._items.Length * 0.9);
        if (this._size < num)
        {
            this.Capacity = this._size;
        }
    }
