    try
    {
    conn.Close();
    }
    catch (InvalidOperationException ex)
    {
    Console.WriteLine(ex.GetType().FullName);
    Console.WriteLine(ex.Message);
    //for Asp.net app
    //Response.Write(ex.GetType().FullName);
    // Response.Write(ex.Message);
    }
