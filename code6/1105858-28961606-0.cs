    public static int ExecuteWithNiceExceptions(this IDbCommand cmd)
    {
        try
        {
            return cmd.ExecuteNonQuery();
        }
        catch(SqlException ex)
        {
            if (ex.Number == 2627)
            {
                throw new PrimaryKeyViolationException(cmd, ex);
            }
            else
            {
                throw;
            }
        }
        catch (OleDbException ex)
        {
            ... 
        }
        ...
    }
