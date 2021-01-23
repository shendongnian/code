    public static const int INVERSE_DIVISION_BY_ZERO = -1; // any value not possible on correct operation will do
    public int Inverse(int a)
    {
        if (a != 0)
        {
            return 1 / a;
        }
        return INVERSE_DIVISION_BY_ZERO;
    }
