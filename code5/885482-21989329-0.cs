    public static void RunWithExceptionHandling(BaseProgram programToRun)
    {
        try
        {
            //do some processing 
            programToRun.Run();
        }
        catch (Exception)
        {
           programToRun.HandleException();//Use the instance :)
        }
    }
