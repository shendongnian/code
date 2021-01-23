    try
    {
           StreamReader reader = new StreamReader(@"C:\temp\query.sql")
    }
    catch
    {
           throw;
    }
    finally
    {
        reader.Close();   // Close call dispose.
    }
