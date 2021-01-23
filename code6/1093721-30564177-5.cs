    using System.Data.Entity.Infrastructure;
    try
    {
        await context.SaveChangesAsync();
    }
    catch(DbUpdateException ex)
    {
        var sqlException = ex.InnerException.InnerException as SqlException;
        if (sqlException != null && sqlException.Number == 2627)
        {
            //violation of primary key constraint has occurred here, act accordingly
            //e.g. pass the populated viewmodel back to the view and return
        }
    }
