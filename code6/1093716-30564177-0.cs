    try
    {
        await context.SaveChangesAsync();
    }
    catch(SqlException ex)
    {
        //check for insert race condition
        if (ex.Number == 2627)
        {
            //violation of primary key constraint here,
            //just pass the already populated viewmodel to the view            
        }
    }
