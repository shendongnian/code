    try
    {
        cl.Enter(ref locktacken);
        // Your code. The lock is tacken
    }
    finally
    {
        if (locktacken)
        {
            cl.Exit();
        }
    }
