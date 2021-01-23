    public static void Add<T>(ref T[] _self, T item)
    {
        Array.Resize(ref _self, _self.Length + 1);
        _self[_self.Length - 1] = item;
    }
