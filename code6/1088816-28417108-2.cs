    public IEnumerable<object> Items
    {
        get
        {
            return Enum.GetValues(typeof(ActionType)).Cast<object>();
        }
     }
