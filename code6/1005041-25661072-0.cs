    public object this[int index]
    {
        get { return list[index]; }
        // The setter I want to check
        set
        {
            if (index < 0 || index >= Count)
            {
                 throw new ArgumentOutOfRangeException("index");
            }
            Contract.EndContractBlock();
            list[index] = value;
        }
    }
