    try
    {
        var result = cmd.ExecuteScalar();
        if (result == null)
        {
            // handle null case
        }
        else if (result is DbNull)
        {
            // handle DbNull case
        }
        else
        {
            // usable result you can cast as appropriate
        }
    }
    catch (Exception ex)
    {
        // Handle all other eventualities
    }
