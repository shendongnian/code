    // using extension method
    int number = 15;
    if (number.IsBetween(0, 12))
    {
       ...
    }
    
    // definition of extension method
    public static bool IsBetween(this int num, int lower, int upper, bool inclusive = false)
    {
        return inclusive
            ? lower <= num && num <= upper
            : lower < num && num < upper;
    }
