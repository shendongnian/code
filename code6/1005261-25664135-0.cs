    public IReadOnlyCollection<LineOrder> ReadOnlyLineOrder
    {
        get
        {
            return LineOrder.ToList().AsReadOnly();
        }
    } 
