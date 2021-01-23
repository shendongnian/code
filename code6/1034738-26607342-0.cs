            try
            {
               //some code here that causes the error
            }
            catch (DbUpdateException ex)
            {
                var updateException = ex.InnerException as UpdateException;
                if (updateException != null)
                {
                    var sqlException = updateException.InnerException as SqlException;
                    // UIX or PK violation, so try to update/insert.
                    var uixViolationCode = 2601;
                    var pkViolationCode = 2627;
                    if (sqlException != null && sqlException.Errors.OfType<SqlError>().Any(se => se.Number == uixViolationCode || se.Number == pkViolationCode))
                    {
                        // handle the required violation
                    }
                    else
                    {
                        // it's something else...
                        throw;
                    }
                }
                else
                {
                    throw;
                }
            }
