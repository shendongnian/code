        try
        {
            try 
            {
                throw new InvalidCastException("testing");
            }
            catch (SomeSpecificException ex)
            {
                Console.WriteLine("Caught SomeSpecificException");
                throw new Exception("testing");
            } 
        }
        catch (Exception ex)
        {
            Console.WriteLine("Caught Exception");
        }
        Console.ReadKey();
