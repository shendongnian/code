    public static decimal GetUnitPrice(int quantity, int minmaxflag, 
                                       IEnumerable<Level> levels)
    {
        Level level;
    
        if (minmaxflag == 1)
        {
            level = levels.Single(l => quantity > l.MinValue && 
                                       (quantity <= l.MaxValue || l.MaxValue == -1));
        }
        else
        {
            level = levels.Single(l => quantity >= l.MinValue && 
                                     (quantity < l.MaxValue || l.MaxValue == -1));
        }
    
        return level.UnitPrice;
    }
    
    public static decimal GetCostOccured(int quantity, int minmaxflag, 
                                         IEnumerable<Level> levels)
    {
        return GetUnitPrice(quantity, minmaxflag, levels) * quantity;
    }
