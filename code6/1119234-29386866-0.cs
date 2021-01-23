    // Read-only property describing how many elements are in the List.
    public int Count {
        get {
            Contract.Ensures(Contract.Result<int>() >= 0);
            return _size; 
        }
    }
