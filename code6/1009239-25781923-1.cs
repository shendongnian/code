    catch(Exception ex)
    {
        foreach(var innerExceptions in ex.EnumerateInnerException())
        {
            Console.Writeline(ex.Message);
        }
    }
