    IProcessorFacade processor = new Processor();
    
    processor.Process(new One());
    processor.Process(new Two());
    processor.Process(new Three());
    
    try
    {
    	processor.Process(new Four());
    }
    catch (InvalidOperationException e)
    {
    	Console.WriteLine(e.Message);
    }
