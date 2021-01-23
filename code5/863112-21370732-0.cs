    public static const int INVERSE_DIVISION_BY_ZERO = 0; // any value not possible on correct operation
    public int Inverse(int a)
    {
        if (a != 0)
        {
            return 1 / a;
        }
        return INVERSE_DIVISION_BY_ZERO;
    }
