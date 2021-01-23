    try
    {
        MyByteProperty = checked(byte.MaxValue + 1);
    }
    catch (System.OverflowException e)
    {
        MyByteProperty = byte.MaxValue;
    }
