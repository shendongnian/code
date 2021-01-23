    public static PaymentResult FindAppropriateResponse(int resultCode)
    {
        switch(resultCode)
        {
             case 1:
                return PaymentResult.LogonError;
             case 2:
                return PaymentResult.Pending;
             case 3:
                 return PaymentResult.Ok;
             default:
                 return PaymentResult.UnknownResult;
             case 1: // Does blow up at compile time
                 return PaymentResult.Something;
        }
    }
