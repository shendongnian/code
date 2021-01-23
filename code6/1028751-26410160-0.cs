    public int LastGoodYear
    {
        get 
        {
            return LastGoodDate.Year; 
        }
        set
        {
            LastGoodDate = new DateTime(value, LastGoodDate.Month, LastGoodDate.Day);
        }
    }
