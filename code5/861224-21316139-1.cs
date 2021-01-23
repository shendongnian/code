    private SqlConnection interna;
    try
    {
        interna = Tconex.GetConnection();
    }
    catch (Exception ex)
    {
        Console.Writeline("Failed to connect: ", ex.Message);
    }
