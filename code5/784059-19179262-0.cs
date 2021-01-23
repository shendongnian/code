    public static void Operation(object input)
    {
        try
        {
            ValidateInput(input);
            //Do Operation
        }
        catch (MySpecificException subSubExceptionType) //Catch most specific exceptions
        {
    
            //Log or process exception
            throw;
        }
        catch (MySpecificException subExceptionType) //Catch specific exception
        {
            //Log or process exception
        }
        catch (Exception exceptionType) //Catch most generic exception
        {
    
            //Log or process exception
        }
        finally
        {
            //Release the resources
        }
    }
    
    private static void ValidateInput(object input)
    {
        if(input == null)
            throw new NoNullAllowedException();
        //Check if properties of input are as expected. If not as expected then throw specific exception with specific message
    }
