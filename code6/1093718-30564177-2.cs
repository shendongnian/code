    try
    {
        await context.SaveChangesAsync();
    }
    catch(System.Data.Entity.Infrastructure.DbUpdateException ex)
    {
        if (ex.InnerException.InnerException is SqlException)
        {
            var sqlException = (SqlException)ex.InnerException.InnerException;
            if (sqlException.Number == 2627)
            {
                //violation of primary key constraint has occurred here, act accordingly
                //e.g. pass the populated viewmodel back to the view and return
            }
        }
    }
