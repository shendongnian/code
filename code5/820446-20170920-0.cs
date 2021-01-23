    try
    {
        CustObj.d_CustDiscount = Convert.ToDecimal(gs_InPutBuffer.Substring(0, 4));
    }
    catch (FormatException e)
    {
        Console.WriteLine(gs_InPutBuffer.Substring(0, 4));
        Console.WriteLine(e.Message);
    }
