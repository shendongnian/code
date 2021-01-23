    static void Main()
    {
        try
        {     
            CheckLogger();            
            Console.WriteLine("loaded successfully");
            Console.ReadLine();
        }
        catch (System.IO.FileNotFoundException e)
        {
            Console.WriteLine("Common dll missing!" + e.Message);
            Console.ReadLine();
        }
    }  
    static void CheckLogger()
    {
        Common.Logger.LogInfo("Testing logger."); //call to the dll
    }
