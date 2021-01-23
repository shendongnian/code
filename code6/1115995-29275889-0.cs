    private int[] _array;
    public void RemoveItem(int item)
    {
        _array = _array.Where(x => x != item).ToArray();
    }
    /// <summary>Gets immutable array</summary>
    public IReadOnlyList<int> Data { get { return _array; } }
