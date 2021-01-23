    private static ConvertToLongLock = new Object();
    
    public static long ConvertToLong()
    {
        lock(ConvertToLongLock)
        {
                float temp = Math.Abs(number);
                long output = 0;
                temp = (temp / 1024) / 1024;
                output = Convert.ToInt64(temp);
                return output;
        }
    }
