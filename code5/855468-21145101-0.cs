        try
        {
            throw new InvalidCastException("testing");
        }
        catch (Exception ex)
        {
            switch(ex.GetType())
            {
            case "SomeSpecificException":
                Console.WriteLine("Caught SomeSpecificException");
                goto default; //if I recall correctly, you need a goto to fall through a switch in c#
                break;
            default:
                Console.WriteLine("Caught Exception");
        }
        Console.ReadKey();
