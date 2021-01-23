    List<int> _nums = new List<int>();
    public ReadOnlyCollection<int> Nums
    {
        get
        {
            return _nums.AsReadOnly();
        }
    }
