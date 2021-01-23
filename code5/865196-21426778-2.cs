    try
    {
        using (var context = new YourEntityContext())
        {
            context.DeviceInstance.Add(new DeviceInstance() { /*Properties*/ });
            context.SaveChanges();
        }
    }
    catch (DbUpdateException ex)
    {
        var sqlexception = ex.InnerException.InnerException as SqlException;
        if (sqlexception != null)
        {
            if (sqlexception.Errors.OfType<SqlError>().Any(se => se.Number == 2601))
            {
                // Duplicate Key Exception
            }
            else
            {
                // Sth Else
                throw;
            }
        }
    }
