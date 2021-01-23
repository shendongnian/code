    public static int NumDigits(int value, double @base)
    {
        if(@base == 1 || @base <= 0 || value == 0)
        {
            throw new Exception();
        }
        double rawlog = Math.Log(Math.Abs(value), @base);
        return rawlog - (rawlog % 1);
    }
