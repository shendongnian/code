    [__DynamicallyInvokable]
    [SecuritySafeCritical]
    public static extern double Round(double a);
    
    [__DynamicallyInvokable]
    public static double Round(double value, int digits)
    {
        if (digits < 0 || digits > 15)
        {
            throw new ArgumentOutOfRangeException("digits", Environment.GetResourceString("ArgumentOutOfRange_RoundingDigits"));
        }
        return Math.InternalRound(value, digits, MidpointRounding.ToEven);
    }
    
    
    [SecuritySafeCritical]
    private static double InternalRound(double value, int digits, MidpointRounding mode)
    {
        unsafe
        {
            if (Math.Abs(value) < Math.doubleRoundLimit)
            {
                double num = Math.roundPower10Double[digits];
                value = value * num;
                if (mode != MidpointRounding.AwayFromZero)
                {
                    value = Math.Round(value);
                }
                else
                {
                    double num1 = Math.SplitFractionDouble(ref value);
                    if (Math.Abs(num1) >= 0.5)
                    {
                        value = value + (double)Math.Sign(num1);
                    }
                }
                value = value / num;
            }
            return value;
        }
    }
