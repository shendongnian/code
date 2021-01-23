    public T this[int index] {
       get {
                if ((uint) index >= (uint)_size) {
                    ThrowHelper.ThrowArgumentOutOfRangeException();
                }
                Contract.EndContractBlock();
                return _items[index]; 
            }
