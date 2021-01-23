    public class List<T>
    {
        private static readonly T[] _emptyArray = new T[0];
        private const int _defaultCapacity = 4;
        private T[] _items;
        private int _size;
        private int _version;
    
        public void Add(T item)
        {
          if (this._size == this._items.Length)
            this.EnsureCapacity(this._size + 1);
    
          this._items[this._size++] = item;
        }
    
        private void EnsureCapacity(int min)
        {
          if (this._items.Length >= min)
            return;
          int num = this._items.Length == 0 ? 4 : this._items.Length * 2;
          if (num < min)
            num = min;
          this.Capacity = num;
        }
    
        public int Capacity
        {
          [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")] get
          {
            return this._items.Length;
          }
          set
          {
            if (value < this._size)
              ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.value, ExceptionResource.ArgumentOutOfRange_SmallCapacity);
            if (value == this._items.Length)
              return;
            if (value > 0)
            {
              T[] objArray = new T[value];
              if (this._size > 0)
                Array.Copy((Array) this._items, 0, (Array) objArray, 0, this._size);
              this._items = objArray;
            }
            else
              this._items = List<T>._emptyArray;
          }
        }
    }
