    public static double Scale(long value, long maxInputValue, long maxOutputValue)
    {
        if (value <= 1)
            return 0; // log is undefined for 0, log(1) = 0
        return maxOutputValue * Math.Log(value) / Math.Log(maxInputValue);
    }
