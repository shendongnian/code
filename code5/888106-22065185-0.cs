    bool success = false;
    try
    {
        ... stuff ...
        success = true; // This has to occur on all "normal" ways of exiting the
                        // block, including return statements.
    }
    finally
    {
        if (!success)
        {
            Dispose();
        }
    }
