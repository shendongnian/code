    public string CountProxy
    {
        get { return Count.ToString(); }
        set
        {
            int n;
            if (int.TryParse(value, out n) && n <= MaxValue)
                Count = n;
        }
    }
