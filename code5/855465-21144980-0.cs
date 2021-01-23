        try
        {
            throw new SomeSpecificException("testing");
        }
        catch (SomeSpecificException ex)
        {
            Console.WriteLine("Caught SomeSpecificException");
            CommonHandling();
        } 
        catch (Exception ex)
        {
            CommonHandling();
        }
    private void CommonHandling() {
        Console.WriteLine("Caught Exception");
    }
