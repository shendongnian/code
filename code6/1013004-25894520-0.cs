    try
    {
    }
    catch (Exception ex)
    {
        Environment.ExitCode = -1;
        Console.Out.WriteLine(ex.Message);
        Application.Exit();
    }
