    try
    {
        // code that can cause various exceptions...
    }
    catch (ArithmeticException e)
    {
        //handle arithmetic exception
    }
    catch (IntegerOverflowException e)
    {
        //handle overflow exception
    }
    catch (CustomException e)
    {
        //handle your custom exception if thrown from try{} on meeting certain conditions.
    }
    catch (Exception e)
    {
        throw new Exception(e); //handle this in the caller method
    }
