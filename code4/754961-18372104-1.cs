    double myNum = -4.0;
    long sign = GetSign(myNum);
    myNum += 8.0 / 2.0 % 4.0; //some operation
    myNum = SetSign(myNum, sign);
    
    static long GetSign(double x)
    {
        return BitConverter.DoubleToInt64Bits(x) & signMask;
    }
    
    static double SetSign(double x, long sign)
    {
        return BitConverter.Int64BitsToDouble(BitConverter.DoubleToInt64Bits(x) & ~signMask | sign);
    }
    
    const long signMask = unchecked((long)(1UL << 63));
