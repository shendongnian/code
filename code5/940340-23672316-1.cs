    private int _id;
    public int ID
    {
        get
        {
            return _id;
        }
        set
        {
            if (value < 0)
            {
                throw new BusinessException("You must provide a non-negative number for ID.");
            }
            _id = value;
        }
    }
