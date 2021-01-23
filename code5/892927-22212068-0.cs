    static double CalcCharge(double hours)
    {
        double result = 0;
        if (hours > 0 && hours < 7)
        {
            result = hours * 2;        
        }
        else if ((hours >= 7 && hours <= 10) || hours > 15)
        {
            result = hours * 3;
        }
        else if (hours >= 11 && hours <= 15)
        {
            result = hours * 4;
        }
        else
        {
             throw new ArgumentOutOfRangeException("there was a problem!");
        }
        return result;
    }
